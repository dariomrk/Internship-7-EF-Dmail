namespace Internship_7_EF_Dmail.Data.Models
{
    public class SpamFlag
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int FlaggedUserId { get; set; }
        public User FlaggedUser { get; set; } = null!;
    }
}
