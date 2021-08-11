using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Models
{
    public class Country
    {
        public Country()
        {
        }

        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }   

        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
