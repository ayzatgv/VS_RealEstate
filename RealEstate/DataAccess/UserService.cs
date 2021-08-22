using RealEstate.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstate.Models;
using System.Data;

namespace RealEstate.DataAccess
{
    public class UserService : MyDataAccess
    {
        public static List<User> Users_Select(int id = 0, string username = null)
        {
            SqlCommand sqlCommand = GetCommand("Users_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 64);

            DataTable dataTable;
            List<User> users;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(username))
                    _username.Value = username;
                else
                    _username.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_username);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                users = User.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }
        public static int Users_Insert(User user)
        {

            SqlCommand sqlCommand = GetCommand("Users_Insert");

            SqlParameter _firstname = new SqlParameter("@FirstName", SqlDbType.NVarChar, 64);
            SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.NVarChar, 64);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 64);
            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 256);
            SqlParameter _passwordSalt = new SqlParameter("@PasswordSalt", SqlDbType.NVarChar, 128);
            SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 64);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(user.Firstname))
                    _firstname.Value = user.Firstname;
                else
                    _firstname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Lastname))
                    _lastname.Value = user.Lastname;
                else
                    _lastname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Password))
                    _password.Value = user.Password;
                else
                    _password.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.PasswordSalt))
                    _passwordSalt.Value = user.PasswordSalt;
                else
                    _passwordSalt.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Phone))
                    _phone.Value = user.Phone;
                else
                    _phone.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_firstname);
                sqlCommand.Parameters.Add(_lastname);
                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_password);
                sqlCommand.Parameters.Add(_passwordSalt);
                sqlCommand.Parameters.Add(_phone);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }
        public static int Users_Update(User user)
        {
            SqlCommand sqlCommand = GetCommand("Users_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _firstname = new SqlParameter("@FirstName", SqlDbType.NVarChar, 64);
            SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.NVarChar, 64);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 64);
            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 256);
            SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 64);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (user.ID != 0)
                    _id.Value = user.ID;
                else
                    _id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Firstname))
                    _firstname.Value = user.Firstname;
                else
                    _firstname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Lastname))
                    _lastname.Value = user.Lastname;
                else
                    _lastname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Password))
                    _password.Value = user.Password;
                else
                    _password.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Phone))
                    _phone.Value = user.Phone;
                else
                    _phone.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_firstname);
                sqlCommand.Parameters.Add(_lastname);
                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_password);
                sqlCommand.Parameters.Add(_phone);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }
            return (int)_result.Value;
        }
    }
}