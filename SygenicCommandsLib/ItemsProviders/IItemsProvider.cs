namespace SygenicCommandsLib;

public interface IItemsProvider<T>
{
    void Push(T t);
    void Push(IEnumerable<T>? items);
    void Push(params T[] items);
    IEnumerable<T> Peek();
    IEnumerable<T> Pop();
}