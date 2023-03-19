using Bogus;

namespace FilterSortExample.Data;

public class MockDatabase
{
    public List<Thing> Things { get; }

    public MockDatabase()
    {
        var id = 1;
        Things = new Faker<Thing>()
            .RuleFor(t => t.Id, _ => id++)
            .RuleFor(t => t.Name, f => f.Commerce.Product())
            .RuleFor(t => t.Date, f => f.Date.Recent())
            .GenerateBetween(100, 150);
    }
}