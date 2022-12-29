using Internship_7_EF_Dmail.Data.Enums;

namespace Internship_7_EF_Dmail.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public UserStatus Status { get; set; }
        public UserRights Rights { get; set; }

        public ICollection<Mail> Sent { get; set; } = new List<Mail>();

        public ICollection<SpamFlag> Flagged { get; set; } = new List<SpamFlag>();

        public ICollection<Recipient> Recieved { get; set; } = new List<Recipient>();
    }
}
