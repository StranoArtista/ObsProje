using ObsProje.Enums;

namespace ObsProje.Models
{
    public class Syllabus:BaseEntity
    {
        public Term Term { get; set; }
        //Relations
        public virtual User? User { get; set; }
        public int UserId { get; set; }
    }
}
