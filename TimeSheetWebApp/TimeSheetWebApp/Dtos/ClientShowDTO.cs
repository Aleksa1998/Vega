using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Dtos
{
    public class ClientShowDTO
    {
        public ClientShowDTO()
        {
        }
        public ClientShowDTO(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
