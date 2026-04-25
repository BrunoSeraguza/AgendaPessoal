using AgendaPessoal.Domain;

namespace AgendaPessoal.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
        Task Add(Person person);
        Task Update(Person person);
        Task Delete(int id);
        Task<bool> EmailExists(string email);
    }
}
