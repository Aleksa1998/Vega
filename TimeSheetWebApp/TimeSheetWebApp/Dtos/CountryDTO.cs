using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Dtos
{
    public class CountryDTO
    {
        public CountryDTO()
        {
        }
        public CountryDTO(Country country)
        {
            Id = country.Id;
            Name = country.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
