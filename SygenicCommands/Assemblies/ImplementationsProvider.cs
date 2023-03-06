namespace SygenicCommands;

internal sealed class ImplementationsProvider : IImplementationsProvider
{
	#region ctor DI
	private readonly IAssemblyProvider assemblyProvider;

	public ImplementationsProvider(IAssemblyProvider assemblyProvider) => this.assemblyProvider = assemblyProvider;
	#endregion

	public IEnumerable<Type> FindConcreteImplementations<T>() => FindConcreteImplementations(typeof(T));

	public IEnumerable<Type> FindConcreteImplementations(Type type)
	{
		var ret = new ItemsProvider<Type>();
		var assemblies = assemblyProvider.Peek();
		foreach (var assembly in assemblies)
		{
			var types = assembly.GetTypes().Where(x => !x.IsAbstract && !x.IsInterface);
			foreach (var item in types)
			{
				if (item.IsAssignableTo(type) || item.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type))
				{
					ret.Push(item);
				}
			}
		}
		return ret.Peek();
	}
}
