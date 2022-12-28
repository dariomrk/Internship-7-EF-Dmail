using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;

namespace Internship_7_EF_Dmail.Domain.Repos
{
    public class MailRepo : BaseRepo
    {
        public MailRepo(DmailDBContext context) : base(context)
        {
        }

        public Mail? GetById(int id) => context.Mails.Find(id);
        public ICollection<Mail> GetAll() => context.Mails.ToList();

        public Response Add(Mail mail)
        {
            context.Mails.Add(mail);
            return SaveChanges();
        }

        public Response Delete(int mailId)
        {
            Mail? toDelete = GetById(mailId);

            if (toDelete == null)
                return Response.ErrorNotFound;

            context.Mails.Remove(toDelete);
            return SaveChanges();
        }
    }
}
