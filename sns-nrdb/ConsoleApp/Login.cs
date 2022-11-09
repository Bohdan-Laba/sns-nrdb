using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sns_nrdb.ConsoleApp
{
    public class Login
    {
        private readonly DbConnection _dbConnection;

        public Login(DbConnection _dbConnection)
        {
            this._dbConnection = _dbConnection;
        }

        public User CurrentUser { get; private set; }

        public bool IsAuthenticated()
        {
            return CurrentUser != null;
        }

        public bool SignIn(string email, string password)
        {
            if (CurrentUser != null)
            {
                throw new Exception("User already signed in, sign out first!");
            }

            var userMongo = _dbConnection.Users.GetByCredentials(email, password);

            if (userMongo != null)
            {
                CurrentUser = userMongo;

                return true;
            }

            return false;
        }

        public void SignOut()
        {
            CurrentUser = null;
        }
    }
}
