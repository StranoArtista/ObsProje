using ObsProje.Enums;

namespace ObsProje.Models
{
    public class Class:BaseEntity
    {
        public string? ClassName { get; set; }
        public string? ClassCode { get; set; }
        
        public Term Term { get; set; }
        //Relations
        public virtual List<User_Class>? User_Classes { get; set; }
        public virtual List<Exam>? Exams { get; set; }
    }
}
