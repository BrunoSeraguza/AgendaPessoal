using AgendaPessoal.Domain;
using AgendaPessoal.Repository;

namespace AgendaPessoal.Service;

public class PersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(Person person)
    {
        if (string.IsNullOrEmpty(person.Email))
            throw new Exception("Email é obrigatório");

        if (await _repository.EmailExists(person.Email))
            throw new Exception("Email já cadastrado");

        if (CalculateAge(person.BirthDate) < 18)
            throw new Exception("Pessoa deve ter pelo menos 18 anos");

        await _repository.Add(person);
    }

    private int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
            age--;

        return age;
    }
}
