using Internship_7_EF_Dmail.Data.Enums;

namespace Internship_7_EF_Dmail.Data.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public MailFormat Format { get; set; }
        public string? Content { get; set; }
        public DateTime? EventStartAt { get; set; }
        public TimeSpan? EventDuration { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public List<Recipient> Recipients { get; set; }
    }
}
