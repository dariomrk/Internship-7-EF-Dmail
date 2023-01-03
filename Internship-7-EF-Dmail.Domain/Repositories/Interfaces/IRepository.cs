using Internship_7_EF_Dmail.Domain.Enums;

namespace Internship_7_EF_Dmail.Domain.Repositories.Interfaces
{
    /// <summary>
    /// Defines a simple CRUD interface.<br/>
    /// In the case a method is not supported throw the <see cref="NotSupportedException"/>.
    /// </summary>
    /// <typeparam name="T">Entity model.</typeparam>
    public interface IRepository<T> where T : class
    {
        public T? GetById(int id);
        public ICollection<T> GetAll();
        public Response Add(T entity);
        public Response Update(T entity);
        public Response Delete(int id);
    }
}
