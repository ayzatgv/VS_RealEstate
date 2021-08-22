using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RealEstate.Models.ViewModels
{
    public class Property_VM_Get
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Meters { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }

        public string Deal { get; set; }
        public string Description { get; set; }

        public Property_VM_Get()
        {

        }
        public static List<Property_VM_Get> Convert(DataTable dataTable)
        {
            List<Property_VM_Get> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Property_VM_Get>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Property_VM_Get Convert(DataRow dataRow)
        {
            Property_VM_Get result = null;

            if (dataRow != null)
            {
                result = new Property_VM_Get();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Title") && dataRow["Title"] != DBNull.Value)
                    result.Title = System.Convert.ToString(dataRow["Title"]);
                if (dataRow.Table.Columns.Contains("UserID") && dataRow["UserID"] != DBNull.Value)
                    result.UserID = System.Convert.ToInt32(dataRow["UserID"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    result.Username = System.Convert.ToString(dataRow["Username"]);
                if (dataRow.Table.Columns.Contains("Phone") && dataRow["Phone"] != DBNull.Value)
                    result.Phone = System.Convert.ToString(dataRow["Phone"]);
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