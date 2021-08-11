using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Dtos
{
    public class ClientDTO
    {
        public ClientDTO()
        {
        }
        public ClientDTO(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Address = client.Address;
            City = client.City;
            PostalCode = client.PostalCode;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public CountryDTO Country { get; set; }
    }
}
