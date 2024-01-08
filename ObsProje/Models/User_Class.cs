namespace ObsProje.Models
{
    public class User_Class:BaseEntity
    {
        public virtual Class? Class { get; set; }
        public int ClassId { get; set; }
        public virtual User? User { get; set; }
        public int UserId { get; set; }

    }
}
