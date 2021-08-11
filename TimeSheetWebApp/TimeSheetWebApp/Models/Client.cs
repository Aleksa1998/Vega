using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Models
{
    public class Client
    {
        public Client()
        {
        }

        public Client(int id, string name, string address, string city, string postalCode, int countryId)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            PostalCode = postalCode;
            CountryId = countryId;
        }
       
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string PostalCode { get; set; }
        public virtual Project Project { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public bool IsDeleted { get; set; }

    }
}
