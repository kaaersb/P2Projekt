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
        private readonly UserRepository userRepository = new UserRepository(); // DAL
        // note to future self: Add a function that checks if a username already exist in the database.
        // For use in the SaveUser function
        public bool SaveUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false; // Validation
            }

            return userRepository.SaveUser(username, password); // Call DAL
        }

        public (bool, string) Validateuser(string username, string password)
        {
            var (isValid, message) = userRepository.ValidateUser(username, password);

            return (isValid, message);
        }
    }
}
