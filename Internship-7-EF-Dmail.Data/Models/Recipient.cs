using Internship_7_EF_Dmail.Data.Enums;

namespace Internship_7_EF_Dmail.Data.Models
{
    public class Recipient
    {
        public int MailId { get; set; }
        public Mail Mail { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public MailStatus? MailStatus { get; set; }
        public EventStatus? EventStatus { get; set; }
    }
}
