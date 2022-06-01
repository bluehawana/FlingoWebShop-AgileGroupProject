using FlingorWebShop.Shared;

namespace FlingorWebShop.Client.DAL
{
    public class UserManager
    {
        private User _loggedInUser;

        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set { _loggedInUser = value; }
        }

        public event EventHandler LoggedInUserUpdated;

        public void CheckLoggedInUser()
        {
            if (_loggedInUser is not null)
            {
                LoggedInUserUpdated.Invoke(this, new EventArgs { });
            }
        }

        public void SetUser(User user)
        {
            _loggedInUser = user;
        }

        public User GetUser()
        {
            return _loggedInUser;
        }
    }
}
