using System.Reflection;

namespace XCheck;

internal static class X
{
	internal static IServiceProvider Services => services ??= CreateServiceProvider();
	private static IServiceProvider? services;

	private static IServiceProvider CreateServiceProvider()
	{
		var serviceCollection = new ServiceCollection();
		serviceCollection.TryAddSygenicCommands(assemblyProviderConfigurator =>
		{
			var executingAssembly = Assembly.GetExecutingAssembly();
			var entryAssembly = Assembly.GetEntryAssembly() ?? throw new Exception("Assembly.GetEntryAssembly() returns null");
			assemblyProviderConfigurator.Push(executingAssembly, entryAssembly);
		});
		var ret = serviceCollection.BuildServiceProvider();
		ret.UseSygenicCommands();
		return ret;
	}
}
