using Internship_7_EF_Dmail.Data.Enums;

namespace Internship_7_EF_Dmail.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserStatus Status { get; set; }
        public UserRights Rights { get; set; }

        public List<Mail> Sent { get; set; }

        public List<SpamFlag> Flagged { get; set; }

        public List<Recipient> Recieved { get; set; }
    }
}
