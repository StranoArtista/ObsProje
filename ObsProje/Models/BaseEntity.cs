using ObsProje.Enums;
using ObsProje.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ObsProje.Models
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Active;
        }

        public int ID { get; set; }

        // Dates
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

        // Users (Will be provided from AppUser class. Only the UserName will be written in the property.)
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }

        // Status (Will be provided from DataStatus enum. Active = 1, Passive = 2, Modified = 3)
        public DataStatus Status { get; set; }
    }
}
