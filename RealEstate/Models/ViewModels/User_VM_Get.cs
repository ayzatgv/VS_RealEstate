using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models.ViewModels
{
    public class User_VM_Get
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }

        public User_VM_Get()
        {

        }
        public User_VM_Get(User user)
        {
            this.ID = user.ID;
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
            this.Username = user.Username;
            this.Phone = user.Phone;
        }
    }
}