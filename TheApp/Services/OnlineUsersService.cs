namespace TheApp.Services
{
    public class OnlineUsersService
    {

        //      Add user when they connect
        //string userId = "someUserId"; // replace with actual user ID
        //OnlineUsersService.Instance.AddUser(userId);

        //      Remove user when they disconnect
        //OnlineUsersService.Instance.RemoveUser(userId);

        //      Get total users online
        //int totalUsersOnline = OnlineUsersService.Instance.GetTotalUsersOnline();

        //      Get list of online user IDs
        //IEnumerable<string> onlineUserIds = OnlineUsersService.Instance.GetOnlineUserIds();


        private readonly HashSet<string> _onlineUserIds = new HashSet<string>();

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

        public void AddUser(string userId)
        {
            lock (_onlineUserIds)
            {
                if (!_onlineUserIds.Contains(userId))
                {
                    _onlineUserIds.Add(userId);
                }
            }
        }

        public void RemoveUser(string userId)
        {
            lock (_onlineUserIds)
            {
                _onlineUserIds.Remove(userId);
            }
        }

        public int GetTotalUsersOnline()
        {
            lock (_onlineUserIds)
            {
                return _onlineUserIds.Count;
            }
        }

        public IEnumerable<string> GetOnlineUserIds()
        {
            lock (_onlineUserIds)
            {
                return _onlineUserIds.ToList();
            }
        }
    }


}
