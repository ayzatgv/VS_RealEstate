using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class Property
    {
        private int _id;
        private string _title;
        private int _userID;
        private string _type;
        private string _province;
        private string _city;
        private string _address;
        private int _meters;
        private int _price;
        private string _date;
        private string _deal;
        private string _description;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public int Meters
        {
            get { return _meters; }
            set { _meters = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Deal
        {
            get { return _deal; }
            set { _deal = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Property()
        {

        }
        public Property(string title, int userID, string type, string province, string city, string address, int meters, int price, string deal, string description)
        {
            Title = title;
            UserID = userID;
            Type = type;
            Province = province;
            City = city;
            Address = address;
            Meters = meters;
            Price = price;
            Date = DateTime.Now.ToString();
            Deal = deal;
            Description = description;
        }

        public static List<Property> Convert(DataTable dataTable)
        {
            List<Property> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Property>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Property Convert(DataRow dataRow)
        {
            Property result = null;

            if (dataRow != null)
            {
                result = new Property();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Title") && dataRow["Title"] != DBNull.Value)
                    result.Title = System.Convert.ToString(dataRow["Title"]);
                if (dataRow.Table.Columns.Contains("UserID") && dataRow["UserID"] != DBNull.Value)
                    result.UserID = System.Convert.ToInt32(dataRow["UserID"]);
                if (dataRow.Table.Columns.Contains("Type") && dataRow["Type"] != DBNull.Value)
                    result.Type = System.Convert.ToString(dataRow["Type"]);
                if (dataRow.Table.Columns.Contains("Province") && dataRow["Province"] != DBNull.Value)
                    result.Province = System.Convert.ToString(dataRow["Province"]);
                if (dataRow.Table.Columns.Contains("City") && dataRow["City"] != DBNull.Value)
                    result.City = System.Convert.ToString(dataRow["City"]);
                if (dataRow.Table.Columns.Contains("Address") && dataRow["Address"] != DBNull.Value)
                    result.Address = System.Convert.ToString(dataRow["Address"]);
                if (dataRow.Table.Columns.Contains("Meters") && dataRow["Meters"] != DBNull.Value)
                    result.Meters = System.Convert.ToInt32(dataRow["Meters"]);
                if (dataRow.Table.Columns.Contains("Price") && dataRow["Price"] != DBNull.Value)
                    result.Price = System.Convert.ToInt32(dataRow["Price"]);
                if (dataRow.Table.Columns.Contains("Date") && dataRow["Date"] != DBNull.Value)
                    result.Date = System.Convert.ToString(dataRow["Date"]);
                if (dataRow.Table.Columns.Contains("Date") && dataRow["Deal"] != DBNull.Value)
                    result.Deal = System.Convert.ToString(dataRow["Deal"]);
                if (dataRow.Table.Columns.Contains("Description") && dataRow["Description"] != DBNull.Value)
                    result.Description = System.Convert.ToString(dataRow["Description"]);
            }
            return result;
        }
    }
}