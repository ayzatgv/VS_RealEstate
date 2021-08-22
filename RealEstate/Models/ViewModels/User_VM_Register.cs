using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models.ViewModels
{
    public class User_VM_Register
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            if (!string.IsNullOrEmpty(this.Firstname))
                user.Firstname = this.Firstname;
            if (!string.IsNullOrEmpty(this.Lastname))
                user.Lastname = this.Lastname;
            if (!string.IsNullOrEmpty(this.Username))
                user.Username = this.Username;
            if (!string.IsNullOrEmpty(this.Password))
            {
                user.PasswordSalt = Guid.NewGuid().ToString("N");
                user.Password = user.HashedPassword(this.Password);
            }
            if (!string.IsNullOrEmpty(this.Phone))
                user.Phone = this.Phone;

            return user;
        }
    }
}