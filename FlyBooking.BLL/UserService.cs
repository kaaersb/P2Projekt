using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyBooking.DAL;

namespace FlyBooking.BLL
{
    public class UserService
    {
        private UserRepository userRepository = new UserRepository(); // DAL

        public bool SaveUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false; // Validation
            }

            return userRepository.SaveUser(username, password); // Call DAL
        }
    }
}
