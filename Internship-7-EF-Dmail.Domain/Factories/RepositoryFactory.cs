using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Domain.Repos;

namespace Internship_7_EF_Dmail.Domain.Factories
{
    public static class RepositoryFactory
    {
        public static TRepo GetRepository<TRepo>() where TRepo : BaseRepo
        {
            DmailDBContext context = DBContextFactory.GetDmailDBContext();
            var repository = Activator.CreateInstance(typeof(TRepo),context) as TRepo;

            return repository!;
        }
    }
}
