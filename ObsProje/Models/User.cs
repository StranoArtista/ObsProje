using Microsoft.AspNetCore.Identity;
using ObsProje.Enums;
using ObsProje.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsProje.Models
{
    public class User : IdentityUser<int>, IEntity
    {

        public User()
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

        //Custom Properties
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? TelNo { get; set; }
        public string? Address { get; set; }
        public string? TCKN { get; set; }


        //Relations

        public virtual List<User_Role>? User_Roles { get; set; }
        public virtual List<User_Class>? User_Classes { get; set; }
        public virtual List<User_Exam>? User_Exams { get; set; }
        public virtual Syllabus? Syllabus { get; set; }
        public int SyllabusId { get; set; }

    }
}
