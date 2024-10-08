using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using TheApp.Objects;
using TheApp.IO.DataCom;
using TheApp.Services;

namespace TheApp.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;

            // Send the connection ID to the client
            await Clients.Caller.SendAsync("ReceiveConnectionId", connectionId);

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string userID, string messageText)
        {
            OnlineUsersService _onlineUsersService;

            _onlineUsersService = OnlineUsersService.Instance;

            // Get the sender's details
            var senderID = _onlineUsersService.GetUserIDByConnectionID(Context.ConnectionId);
            var senderName = new GetUsers().GetUser(int.Parse(userID)); 
            var picurl = "URL_to_sender_pic"; // Replace
            var timeStamp = DateTime.Now.ToString();

            // Create a Message object
            var message = new Message
            {
                senderID = int.Parse(senderID),
                receiverID = int.Parse(userID), /* Get the receiver's ID based on the provided userID */ 
                readMessage = 0,
                sent = 1,
                deleted = 0,
                messageText = messageText,
                DateTime = DateTime.Now
            };

            // Use the CreateMessage class to insert the message into the database
            var createMessage = new CreateMessage();
            int messageId = createMessage.InsertMessage(message);

            // Get the recipient's connection ID from the OnlineUsersService
            var recipientConnectionId = OnlineUsersService.Instance.GetConnectionId(userID);

            if (recipientConnectionId != null)
            {
                // User is online, send the message directly to the user
                await Clients.Client(recipientConnectionId).SendAsync("ReceiveMessage",
                    new { senderName, userID, picurl, messageText, timeStamp });
            }

            // You can now store the messageId or perform additional logic as needed
        }

        // Method to add a user to OnlineUsersService, call this from your login logic
        public void AddUserToOnlineUsers(string userID)
        {
            var connectedClientId = Context.ConnectionId;
            OnlineUsersService.Instance.AddUser(userID, connectedClientId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Get the connection ID of the disconnected client
            var connectionId = Context.ConnectionId;

            OnlineUsersService _onlineUsersService;

            _onlineUsersService = OnlineUsersService.Instance;

            // Find the user ID associated with the connection ID and remove the user
            _onlineUsersService.RemoveUserByConnectionId(connectionId);

            await base.OnDisconnectedAsync(exception);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task EnableMessages()
        {
            await Clients.User(Context.ConnectionId).SendAsync("EnableMessages");
        }

    }
}



