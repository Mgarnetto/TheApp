using System.Collections.Generic;
using System.Linq;

namespace TheApp.Services
{
    public class OnlineUsersService
    {
        private readonly Dictionary<string, string> _userConnectionMap = new Dictionary<string, string>();
        private static OnlineUsersService _instance;
        private static readonly object _lock = new object();

        private OnlineUsersService()
        {
            // Private constructor to enforce singleton pattern
        }

        public static OnlineUsersService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new OnlineUsersService();
                    }
                    return _instance;
                }
            }
        }

        public void AddUser(string userId, string connectionId)
        {
            lock (_userConnectionMap)
            {
                if (!_userConnectionMap.ContainsKey(userId))
                {
                    _userConnectionMap.Add(userId, connectionId);
                }
            }
        }

        public void RemoveUserByConnectionId(string connectionId)
        {
            lock (_userConnectionMap)
            {
                // Find the key (userId) based on the provided connectionId
                var userIdToRemove = _userConnectionMap.FirstOrDefault(x => x.Value == connectionId).Key;

                // If a matching key is found, remove the entry
                if (userIdToRemove != null)
                {
                    _userConnectionMap.Remove(userIdToRemove);
                }
            }
        }

        public string GetUserIDByConnectionID(string connectionId)
        {
            return _userConnectionMap.FirstOrDefault(x => x.Value == connectionId).Key;
        }


        public void RemoveUser(string userId)
        {
            lock (_userConnectionMap)
            {
                _userConnectionMap.Remove(userId);
            }
        }

        public int GetTotalUsersOnline()
        {
            lock (_userConnectionMap)
            {
                return _userConnectionMap.Count;
            }
        }

        public IEnumerable<string> GetOnlineUserIds()
        {
            lock (_userConnectionMap)
            {
                return _userConnectionMap.Keys.ToList();
            }
        }

        public string GetConnectionId(string userId)
        {
            lock (_userConnectionMap)
            {
                return _userConnectionMap.ContainsKey(userId) ? _userConnectionMap[userId] : null;
            }
        }
    }
}
