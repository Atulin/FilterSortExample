using FilterSortExample.Data;
using FilterSortExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilterSortExample.Controllers;

public class HomeController : Controller
{
    private readonly MockDatabase _db;

    public HomeController(MockDatabase db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index(string? filter, SortOption? sort)
    {
        var q = _db.Things.AsEnumerable();

        if (!string.IsNullOrEmpty(filter))
        {
            q = q.Where(t => t.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        if (sort is { } s)
        {
            q = s switch
            {
                SortOption.IdAsc => q.OrderBy(t => t.Id),
                SortOption.IdDesc => q.OrderByDescending(t => t.Id),
                SortOption.NameAsc => q.OrderBy(t => t.Name),
                SortOption.NameDesc => q.OrderByDescending(t => t.Name),
                SortOption.DateAsc => q.OrderBy(t => t.Date),
                SortOption.DateDesc => q.OrderByDescending(t => t.Date),
                _ => q
            };
        }

        var data = q.ToList();
        
        return View(new HomeModel
        {
            Things = data,
            Filter = filter,
            Sort = sort
        });
    }
}