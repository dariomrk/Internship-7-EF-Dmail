using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_EF_Dmail.Domain.Repositories
{
    public class MailRepository : BaseRepository, IRepository<Mail>
    {
        public MailRepository(DmailDBContext context) : base(context)
        {
        }

        public Mail? GetById(int id)
        {
            return context.Mails.Find(id);
        }

        public ICollection<Mail> GetAll()
        {
            return context.Mails
            .Include(m => m.Sender)
            .Include(m => m.Recipients)
            .ToList();
        }

        public ICollection<Mail> GetWhereSender(int senderId)
        {
            return GetAll().Where(m => m.SenderId == senderId).ToList();
        }

        public ICollection<Mail> GetWhereSenderAndNotHidden(int senderId)
        {
            return GetAll()
            .Where(m => m.SenderId == senderId && !m.HiddenFromSender)
            .ToList();
        }

        public ICollection<Mail> GetWhereReciever(int recieverId)
        {
            return GetAll()
            .Join(context.Recipients,
            m => m.Id,
            r => r.MailId,
            (m, r) => new { m, r })
            .Where(a => a.r.UserId == recieverId)
            .Select(a => a.m)
            .ToList();
        }

        public ICollection<Mail> GetWhereRecieverAndNotDeleted(int recieverId)
        {
            return GetAll()
            .Join(context.Recipients,
            m => m.Id,
            r => r.MailId,
            (m, r) => new { m, r })
            .Where(a => a.r.UserId == recieverId && a.r.MailStatus != MailStatus.Deleted)
            .Select(a => a.m)
            .ToList();
        }

        public ICollection<Mail> GetWhereSenderAndRecipient(int senderId, int recipientId)
        {
            return GetWhereSender(senderId)
            .Join(GetWhereRecieverAndNotDeleted(recipientId),
            s => s.Id,
            r => r.Id,
            (s, r) => new { s, r })
            .Select(a => a.r)
            .ToList();
        }

        public ICollection<Mail> GetWhereRecieverAndStatus(int recieverId, MailStatus status)
        {
            return GetAll()
            .Join(context.Recipients,
            m => m.Id,
            r => r.MailId,
            (m, r) => new { m, r })
            .Where(a => a.r.UserId == recieverId && a.r.MailStatus == status)
            .Select(a => a.m)
            .ToList();
        }

        public ICollection<User> GetRecipients(int mailId)
        {
            return context.Recipients.Where(r => r.MailId == mailId)
            .Join(context.Users,
            m => m.UserId,
            u => u.Id,
            (m, u) => new { m, u })
            .Select(a => a.u)
            .ToList();
        }

        public ICollection<Mail> GetEmails()
        {
            return GetAll().Where(m => m.Format == Data.Enums.MailFormat.Email).ToList();
        }

        public ICollection<Mail> GetEvents()
        {
            return GetAll().Where(m => m.Format == Data.Enums.MailFormat.Event).ToList();
        }

        public ICollection<Mail> GetSpam(int recieverId)
        {
            return GetWhereReciever(recieverId)
            .Join(context.SpamFlags,
            m => m.SenderId,
            sf => sf.UserId,
            (m, sf) => new { m, sf })
            .Select(a => a.m)
            .ToList();
        }

        public Response Add(Mail mail)
        {
            if (mail.Format == Data.Enums.MailFormat.Email && mail.Content == null)
            {
                return Response.ErrorInvalidFormat;
            }

            if (mail.Format == Data.Enums.MailFormat.Event &&
                (mail.EventStartAt == null || mail.EventDuration == null))
            {
                return Response.ErrorInvalidFormat;
            }

            context.Mails.Add(mail);
            return SaveChanges();
        }

        public Response Update(Mail m)
        {
            throw new NotSupportedException("Use specific update method (UpdateMailStatus...).");
        }

        public Response UpdateMailStatus(int mailId, int userId, Data.Enums.MailStatus status)
        {
            Mail? toChange = GetWhereReciever(userId).FirstOrDefault(m => m.Id == mailId);

            if (toChange == null)
            {
                return Response.ErrorNotFound;
            }

            Recipient recipient = context.Recipients.Find(mailId, userId)!;

            recipient.MailStatus = status;

            return SaveChanges();
        }

        public Response UpdateEventStatus(int mailId, int userId, Data.Enums.EventStatus status)
        {
            Mail? toChange = GetWhereReciever(userId).FirstOrDefault(m => m.Id == mailId);

            if (toChange == null)
            {
                return Response.ErrorNotFound;
            }

            if (toChange.Format != Data.Enums.MailFormat.Event)
            {
                return Response.ErrorInvalidFormat;
            }

            Recipient recipient = context.Recipients.Find(mailId, userId)!;

            recipient.EventStatus = status;

            return SaveChanges();
        }

        public Response Delete(int mailId)
        {
            throw new NotSupportedException("Cannot delete a mail by id.");
        }

        public Response RemoveFromInbox(int mailId, int userId)
        {
            Mail? toRemove = GetWhereReciever(userId).FirstOrDefault(m => m.Id == mailId);

            if (toRemove == null)
            {
                return Response.ErrorNotFound;
            }

            Recipient recipient = context.Recipients.Find(mailId, userId)!;

            recipient.MailStatus = MailStatus.Deleted;

            return SaveChanges();
        }

        public Response RemoveFromOutbox(int mailId)
        {
            Mail? toHide = GetById(mailId);

            if (toHide == null)
            {
                return Response.ErrorNotFound;
            }

            toHide.HiddenFromSender = true;

            return SaveChanges();
        }
    }

}
