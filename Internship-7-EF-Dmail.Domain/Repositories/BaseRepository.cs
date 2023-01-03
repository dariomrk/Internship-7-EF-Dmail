using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Domain.Enums;

namespace Internship_7_EF_Dmail.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DmailDBContext context;

        protected BaseRepository(DmailDBContext context)
        {
            this.context=context;
        }

        protected Response SaveChanges()
        {
            if (context.SaveChanges() > 0)
                return Response.Succeeded;
            return Response.NoChanges;
        }
    }
}
