using System;
using System.Collections.Generic;
using System.IO;


namespace QuickFixProject.DataLayer
{
    internal class Users
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Role { get; set; }
        //public string SecurityQuestion { get; set; }
        //public string SecurityAnswer { get; set; }

        public override string ToString()
        {
            return $"{UserID},{Username},{Password},{IsAdmin},{Role}";
            //+ "," + SecurityQuestion + "," + SecurityAnswer;
        }
    }

    class UsersData
    {
        private readonly string filePath = "C:\\Users\\Mohammed Rafathullah\\source\\repos\\QuickFixProject\\QuickFixProject\\Data\\Users.csv";
        List<Users> users = new List<Users>();

        public UsersData()
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        Users u = new Users()
                        {
                            UserID = values[0],
                            Username = values[1],
                            Password = values[2],
                            IsAdmin = Convert.ToBoolean(values[3]),
                            Role = values[4]
                        };

                        users.Add(u);
                    }
                }
            }
        }

        public List<Users> GetAllUsers()
        {
            return users;
        }

        public Users GetUserByid(string userId)
        {
            foreach (var user in users)
            {
                if (user.UserID == userId)
                {
                    return user;
                }
            }

            return null;
        }

        public List<Users> GetAllTechnicians()
        {
            List <Users> lu = new List<Users>();
            foreach (var user in users)
            {
                if (user.Role == "Technician")
                {
                    lu.Add(user);
                }
            }

            return lu;
        }

        public string CustomerLogin(string userId, string password)
        {
            Users u = GetUserByid(userId);

            if (u != null)
            {
                if (u.UserID == userId && u.Password == password && u.Role == "Customer")
                {
                    return "Login Success";
                }
                else
                {
                    return "Invalid User Id or Password";
                }
            }
            else
            {
                return "User does not exists";
            }
        }

        public string TechnicianLogin(string userId, string password)
        {
            Users u = GetUserByid(userId);

            if (u != null)
            {
                if (u.UserID == userId && u.Password == password && u.Role == "Technician")
                {
                    return "Login Success";
                }
                else
                {
                    return "Invalid User Id or Password";
                }
            }
            else
            {
                return "User does not exists";
            }
        }

        public string AdminLogin(string userId, string password)
        {
            Users u = GetUserByid(userId);

            if (u != null)
            {
                if (u.IsAdmin)
                {
                    if (u.UserID == userId && u.Password == password)
                    {
                        return "Login Success";
                    }
                    else
                    {
                        return "Invalid User Id or Password";
                    }
                }
                else
                {
                    return "You are not an admin. Please login as a customer";
                }
            }
            else
            {
                return "User does not exists";
            }
        }

        public string UpdatePassword(string userId, string newPassword)
        {
            try
            {
                bool result = false;
                List<string> lines = new List<string>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(","))
                        {
                            string[] split = line.Split(',');

                            if (split[0].Contains(userId))
                            {
                                result = true;
                                split[2] = newPassword;
                                line = string.Join(",", split);
                            }
                        }

                        lines.Add(line);
                    }
                }

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (string line in lines)
                        writer.WriteLine(line);
                }
                if (result)
                {
                    return "Password updated successfully";
                }
                else
                {
                    return "User does not exists.";
                }
            }
            catch (Exception)
            {
                return "Failed to update password, error occured";
            }
        }

        //public bool SecurityQuestionCheck(string userId, string question, string answer)
        //{
        //    bool result = false;
        //    Users user = GetUserByid(userId);

        //    if (user != null)
        //    {
        //        if (user.SecurityQuestion == question && user.SecurityAnswer == answer)
        //        {
        //            result = true;
        //        }
        //        else
        //        {
        //            result = false;
        //        }
        //    }

        //    return result;
        //}

        public string CreateNewUser(Users newUser)
        {
            var u = GetUserByid(newUser.UserID);

            if (u != null)
            {
                return "User with this User ID already exists";
            }
            else
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        var user = new Users();
                        user.UserID = newUser.UserID;
                        user.IsAdmin = newUser.IsAdmin;
                        user.Username = newUser.Username;
                        user.Password = newUser.Password;
                        user.Role = newUser.Role;
                        //user.SecurityAnswer = newUser.SecurityAnswer;
                        //user.SecurityQuestion = newUser.SecurityQuestion;

                        writer.WriteLine(user.ToString());

                    }

                    return "New user created successfully";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create new user", ex.Message);
                    return null;
                }
            }
        }
    }
}
