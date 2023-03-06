namespace SygenicCommands;

public class ItemsProvider<T> : IItemsProvider<T>
{
    protected readonly HashSet<T> cache = new();

    public IEnumerable<T> Peek() => cache.AsEnumerable();

    public IEnumerable<T> Pop()
    {
        var ret = Peek();
        cache.Clear();
        return ret;
    }

    public void Push(T item) => cache.Add(item);

    public void Push(IEnumerable<T>? items)
    {
        if (items is null) return;
        foreach (var item in items) Push(item);
    }

    public void Push(params T[] items) => Push(items.AsEnumerable());
}