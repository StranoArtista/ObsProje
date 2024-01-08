using ObsProje.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsProje.Interfaces
{
    public interface IEntity
    {
        int ID { get; set; }

        // Dates
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        DateTime DeletedDate { get; set; }

        // Users
        string? CreatedBy { get; set; }
        string? UpdatedBy { get; set; }
        string? DeletedBy { get; set; }

        // Status (ENUM)
        DataStatus Status { get; set; }
    }
}
