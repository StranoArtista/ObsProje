namespace ObsProje.Models
{
    public class User_Exam:BaseEntity
    {
        public virtual Exam? Exam { get; set; }
        public int ExamId { get; set; }
        public virtual User? User { get; set; }
        public int UserId { get; set; }

    }
}
