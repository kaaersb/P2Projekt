using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public class UserRepository
    {
        private readonly string connectionString = "Server=localhost;Database=testuserdb;User ID=root;Password=P2ProjektMarcusMarcusson;";

        public bool SaveUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO testuserdb.users (user_name, user_password) VALUES (@Username, @Password)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        
        public bool ChangePassword(string username, string newPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE testuserdb.users user_password = @Password WHERE user_name = @user_name";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteUser(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM testuserdb.users WHERE user_name = @Username";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public (bool, string) ValidateUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT user_password FROM testuserdb.users WHERE user_name = @Username";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["user_password"].ToString();

                            if (password == storedPassword)
                            {
                                return (true, "Login successfull!");
                            }
                            else
                            {
                                return (false, "Invalid password.");
                            }
                        }
                        else
                        {
                            return (false, "User not found.");
                        }
                        // Note to future marcus: if you want to move the logic to the BLL make it so the function
                        // returns a boolean and a string(storedPassword). If the bool is false that means
                        // the user was not found
                    }
                }
            }
        }
        //User.Add(id, navn, e-mail, password)
        public bool Add(string id, string name, string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO testuserdb.users (user_id, user_name, user_email, user_password) VALUES (@Id, @Name, @Email, @Password)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public (bool, string) ValidateUser2(string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT user_password FROM testuserdb.users WHERE user_email = @Email";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["user_password"].ToString();

                            if (password == storedPassword)
                            {
                                return (true, "Login successfull!");
                            }
                            else
                            {
                                return (false, "Invalid password.");
                            }
                        }
                        else
                        {
                            return (false, "User not found.");
                        }
                        // Note to future marcus: if you want to move the logic to the BLL make it so the function
                        // returns a boolean and a string(storedPassword). If the bool is false that means
                        // the user was not found
                    }
                }
            }
        }

    }
}