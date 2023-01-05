using Internship_7_EF_Dmail.Data.Enums;

namespace Internship_7_EF_Dmail.Data.Models
{
    public class Recipient
    {
        public int MailId { get; set; }
        public Mail Mail { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public MailStatus? MailStatus { get; set; }
        public EventStatus? EventStatus { get; set; }

        public Recipient()
        {
        }

        public Recipient(int recipientId)
        {
            UserId = recipientId;
        }
    }
}
