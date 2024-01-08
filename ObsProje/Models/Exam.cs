namespace ObsProje.Models
{
    public class Exam:BaseEntity
    {
        
        public string Explanation { get; set; }

        //Relations
        public virtual List<User_Exam>? User_Exams { get; set; }
        public virtual Class? Class { get; set; }
        public int ClassID { get; set; }
    }
}
