using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstate.Models;
using RealEstate.Helpers;
using System.Data.SqlClient;
using System.Data;
using RealEstate.Models.ViewModels;

namespace RealEstate.DataAccess
{
    public class PropertyService : MyDataAccess
    {
        public static int Properties_Insert(Property property)
        {

            SqlCommand sqlCommand = GetCommand("Properties_Insert");

            SqlParameter _title = new SqlParameter("@Title", SqlDbType.NVarChar, 128);
            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _type = new SqlParameter("@Type", SqlDbType.NVarChar, 64);
            SqlParameter _province = new SqlParameter("@Province", SqlDbType.NVarChar, 64);
            SqlParameter _city = new SqlParameter("@City", SqlDbType.NVarChar, 64);
            SqlParameter _Address = new SqlParameter("@Address", SqlDbType.NVarChar, 128);
            SqlParameter _meters = new SqlParameter("@Meters", SqlDbType.Int);
            SqlParameter _price = new SqlParameter("@Price", SqlDbType.Int);
            SqlParameter _date = new SqlParameter("@Date", SqlDbType.NVarChar, 64);
            SqlParameter _deal = new SqlParameter("@Deal", SqlDbType.NVarChar, 64);
            SqlParameter _description = new SqlParameter("@Description", SqlDbType.NVarChar, 256);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(property.Title))
                    _title.Value = property.Title;
                else
                    _title.Value = DBNull.Value;

                if (property.UserID != 0)
                    _userID.Value = property.UserID;
                else
                    _userID.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Type))
                    _type.Value = property.Type;
                else
                    _type.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Province))
                    _province.Value = property.Province;
                else
                    _province.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.City))
                    _city.Value = property.City;
                else
                    _city.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Address))
                    _Address.Value = property.Address;
                else
                    _Address.Value = DBNull.Value;

                if (property.Meters != 0)
                    _meters.Value = property.Meters;
                else
                    _meters.Value = DBNull.Value;

                if (property.Price != 0)
                    _price.Value = property.Price;
                else
                    _price.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Date))
                    _date.Value = property.Date;
                else
                    _date.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Deal))
                    _deal.Value = property.Deal;
                else
                    _deal.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Description))
                    _description.Value = property.Description;
                else
                    _description.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_title);
                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_type);
                sqlCommand.Parameters.Add(_province);
                sqlCommand.Parameters.Add(_city);
                sqlCommand.Parameters.Add(_Address);
                sqlCommand.Parameters.Add(_meters);
                sqlCommand.Parameters.Add(_price);
                sqlCommand.Parameters.Add(_date);
                sqlCommand.Parameters.Add(_deal);
                sqlCommand.Parameters.Add(_description);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }
        public static int Properties_Update(Property property)
        {
            SqlCommand sqlCommand = GetCommand("Properties_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _title = new SqlParameter("@Title", SqlDbType.NVarChar, 128);
            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _type = new SqlParameter("@Type", SqlDbType.NVarChar, 64);
            SqlParameter _province = new SqlParameter("@Province", SqlDbType.NVarChar, 64);
            SqlParameter _city = new SqlParameter("@City", SqlDbType.NVarChar, 64);
            SqlParameter _Address = new SqlParameter("@Address", SqlDbType.NVarChar, 128);
            SqlParameter _meters = new SqlParameter("@Meters", SqlDbType.Int);
            SqlParameter _price = new SqlParameter("@Price", SqlDbType.Int);
            SqlParameter _deal = new SqlParameter("@Deal", SqlDbType.NVarChar, 64);
            SqlParameter _description = new SqlParameter("@Description", SqlDbType.NVarChar, 256);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (property.ID != 0)
                    _id.Value = property.ID;
                else
                    _id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Title))
                    _title.Value = property.Title;
                else
                    _title.Value = DBNull.Value;

                if (property.UserID != 0)
                    _userID.Value = property.UserID;
                else
                    _userID.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Type))
                    _type.Value = property.Type;
                else
                    _type.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Province))
                    _province.Value = property.Province;
                else
                    _province.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.City))
                    _city.Value = property.City;
                else
                    _city.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Address))
                    _Address.Value = property.Address;
                else
                    _Address.Value = DBNull.Value;

                if (property.Meters != 0)
                    _meters.Value = property.Meters;
                else
                    _meters.Value = DBNull.Value;

                if (property.Price != 0)
                    _price.Value = property.Price;
                else
                    _price.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Deal))
                    _deal.Value = property.Deal;
                else
                    _deal.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(property.Description))
                    _description.Value = property.Description;
                else
                    _description.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_title);
                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_type);
                sqlCommand.Parameters.Add(_province);
                sqlCommand.Parameters.Add(_city);
                sqlCommand.Parameters.Add(_Address);
                sqlCommand.Parameters.Add(_meters);
                sqlCommand.Parameters.Add(_price);
                sqlCommand.Parameters.Add(_deal);
                sqlCommand.Parameters.Add(_description);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }
        public static int Properties_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Properties_Delete");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }

        public static List<Property_VM_Get> Properties_Select(int id = 0, int userID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Properties_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);

            DataTable dataTable;
            List<Property_VM_Get> properties;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;
                if (userID != 0)
                    _userID.Value = userID;
                else
                    _userID.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_userID);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                properties = Property_VM_Get.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return properties;
        }
    }
}