using AgendaPessoal.Data;
using AgendaPessoal.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgendaPessoal.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> GetAll()
        => await _context.Persons.ToListAsync();

    public async Task<Person> GetById(int id)
        => await _context.Persons.FindAsync(id);

    public async Task Add(Person person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Person person)
    {
        _context.Persons.Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var person = await GetById(id);
        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> EmailExists(string email)
        => await _context.Persons.AnyAsync(x => x.Email == email);
}
