namespace AgendaPessoal.Domain;

public class Person
{

    public int? Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public int Age => DateTime.Today.Year - BirthDate.Year;
}
