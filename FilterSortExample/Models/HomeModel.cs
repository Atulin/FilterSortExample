using FilterSortExample.Data;

namespace FilterSortExample.Models;

public class HomeModel
{
    public List<Thing> Things { get; set; } = new();
    public string? Filter { get; set; }
    public SortOption? Sort { get; set; }
}