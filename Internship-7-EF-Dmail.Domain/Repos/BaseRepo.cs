using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Domain.Enums;

namespace Internship_7_EF_Dmail.Domain.Repos
{
    public abstract class BaseRepo
    {
        protected readonly DmailDBContext context;

        protected BaseRepo(DmailDBContext context)
        {
            this.context=context;
        }

        protected Response SaveChanges()
        {
            if(context.SaveChanges() > 0)
                return Response.Succeeded;
            return Response.NoChanges;
        }
    }
}
