using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Models
{
    public class LeadRelationship
    {
        public LeadRelationship()
        {
        }

        public LeadRelationship(int id, int projectId, int employeeId)
        {
            Id = id;
            ProjectId = projectId;
            EmployeeId = employeeId;
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
