namespace Internship_7_EF_Dmail.Data.Entities.Models
{
    public class SpamFlag
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FlaggedUserId { get; set; }
        public User FlaggedUser { get; set; }
    }
}
