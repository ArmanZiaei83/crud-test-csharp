namespace Mc2.CrudTest.Infrastructure.Shared.Extensions;

public static class ForEachExtenstion
{
    public static void ForEach<T>(this IEnumerable<T> source,
        Action<T> action)
    {
        using IEnumerator<T> enumerator = source.GetEnumerator();
        while (enumerator.MoveNext()) action(enumerator.Current);
    }
}