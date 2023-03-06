namespace SygenicCommandsLib;

public interface IImplementationsProvider
{
	IEnumerable<Type> FindConcreteImplementations<T>();
	IEnumerable<Type> FindConcreteImplementations(Type type);
}