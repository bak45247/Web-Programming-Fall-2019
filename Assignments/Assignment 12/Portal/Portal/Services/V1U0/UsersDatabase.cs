using Portal.Models.V1U0;
using System;
using System.Collections.Generic;

namespace Portal.Services.V1U0
{
    public class UsersDatabase
    {
        public List<UserModel> users = new List<UserModel>();

        public UsersDatabase()
        { 
            users.Add(new UserModel() { Username = "Glados", Password = "Cake" });
            users.Add(new UserModel() { Username = "i", Password = "i" });
            users.Add(new UserModel() { Username = "Password", Password = "Username" });
            users.Add(new UserModel() { Username = "Visual", Password = "Studio" });
        }

        public UserModel GetUser(string username)
        {
            UserModel toReturn = new UserModel();

            for (int i = 0; i < users.Count; i++)
            {
                if (username.Equals(users[i].Username))
                {
                    toReturn = users[i];
                    break;
                }
            }

            return toReturn;
        }

        internal bool IsValidUser(string username)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (username.Equals(users[i].Username))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
