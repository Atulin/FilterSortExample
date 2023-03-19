namespace FilterSortExample.Data;

public enum SortOption
{
    IdAsc,
    IdDesc,
    NameAsc,
    NameDesc,
    DateAsc,
    DateDesc
}

public static class EnumUtil
{
    public static List<(int id, string name)> ToList<T>() where T : struct, Enum =>
        Enum.GetValues<T>()
            .Select((v, k) => (k, v.ToString()))
            .ToList();
}