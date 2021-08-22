using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models.ViewModels
{
    public class Property_VM_List
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Meters { get; set; }
        public int Price { get; set; }
        public string Deal { get; set; }
        public string Description { get; set; }

        public Property ConvertToModel(int userID)
        {
            Property property = new Property();

            if (!string.IsNullOrEmpty(this.Title))
                property.Title = this.Title;
            if (userID != 0)
                property.UserID = userID;
            if (!string.IsNullOrEmpty(this.Type))
                property.Type = this.Type;
            if (!string.IsNullOrEmpty(this.Province))
                property.Province = this.Province;
            if (!string.IsNullOrEmpty(this.City))
                property.City = this.City;
            if (!string.IsNullOrEmpty(this.Address))
                property.Address = this.Address;
            if (this.Meters != 0)
                property.Meters = this.Meters;
            if (this.Price != 0)
                property.Price = this.Price;
            property.Date = DateTime.Now.ToString();
            if (!string.IsNullOrEmpty(this.Deal))
                property.Deal = this.Deal;
            if (!string.IsNullOrEmpty(this.Description))
                property.Description = this.Description;

            return property;
        }
    }
}