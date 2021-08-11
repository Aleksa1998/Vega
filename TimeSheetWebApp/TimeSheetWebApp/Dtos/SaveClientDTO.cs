using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Dtos
{
    public class SaveClientDTO
    {
        public SaveClientDTO()
        {
        }
        public SaveClientDTO(string name, string address, string city, string postalCode, string country)
        {
            Name = name;
            Address = address;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
