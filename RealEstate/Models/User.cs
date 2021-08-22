using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace RealEstate.Models
{
    public class User
    {
        private int _id;
        private string _username;
        private string _password;
        private string _passwordSalt;
        private string _firstname;
        private string _lastname;
        private string _phone;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public User()
        {

        }
        public User(string firstname, string lastname, string username, string password, string phone)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            PasswordSalt = Guid.NewGuid().ToString("N");
            Password = HashedPassword(password);
            Phone = phone;
        }
        public User(int id, string firstname, string lastname, string username, string password, string passwordSalt, string phone)
        {
            ID = id;
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            PasswordSalt = passwordSalt;
            Password = password;
            Phone = phone;
        }

        public static List<User> Convert(DataTable dataTable)
        {
            List<User> users = new List<User>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    users.Add(Convert(item));
                }
            }
            return users;
        }
        public static User Convert(DataRow dataRow)
        {
            User user = null;

            if (dataRow != null)
            {
                user = new User();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    user.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Firstname") && dataRow["Firstname"] != DBNull.Value)
                    user.Firstname = System.Convert.ToString(dataRow["Firstname"]);
                if (dataRow.Table.Columns.Contains("Lastname") && dataRow["Lastname"] != DBNull.Value)
                    user.Lastname = System.Convert.ToString(dataRow["Lastname"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    user.Username = System.Convert.ToString(dataRow["Username"]);
                if (dataRow.Table.Columns.Contains("PasswordSalt") && dataRow["PasswordSalt"] != DBNull.Value)
                    user.PasswordSalt = System.Convert.ToString(dataRow["PasswordSalt"]);
                if (dataRow.Table.Columns.Contains("Password") && dataRow["Password"] != DBNull.Value)
                    user.Password = System.Convert.ToString(dataRow["Password"]);
                if (dataRow.Table.Columns.Contains("Phone") && dataRow["Phone"] != DBNull.Value)
                    user.Phone = System.Convert.ToString(dataRow["Phone"]);
            }
            return user;
        }
        public string HashedPassword(string password)
        {
            var saltedPassword = password + PasswordSalt;
            var saltedPasswordByBytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
            return System.Convert.ToBase64String(SHA512.Create().ComputeHash(saltedPasswordByBytes));
        }
    }
}