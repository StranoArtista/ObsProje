using Microsoft.AspNetCore.Identity;
using ObsProje.Enums;
using ObsProje.Interfaces;
using ObsProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsProje.Models
{
    public class User_Role : IdentityUserRole<int>, IEntity
    {
        public User_Role()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Active;
        }
        //IEntity Properties 
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DataStatus Status { get; set; }

        //Relations

        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }



    }
}
