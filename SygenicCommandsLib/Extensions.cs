namespace SygenicCommandsLib;

public static class Extensions
{
	public static IServiceCollection TryAddSygenicCommands(this IServiceCollection services, Action<AssemblyProvider>? assemblyProviderConfigurator = null)
	{
		services.TryAddTransient<IImplementationsProvider, ImplementationsProvider>();

		var assemblyProvider = new AssemblyProvider();
		assemblyProviderConfigurator?.Invoke(assemblyProvider);
		services.TryAddSingleton<IAssemblyProvider>(assemblyProvider);

		var registry = new CmdRegistry(new ImplementationsProvider(assemblyProvider));
		registry.FindAndRegisterCmdsAsTransients(services);
		services.TryAddSingleton<ICmdRegistry>(registry);
		
		return services;
	}

	public static void UseSygenicCommands(this IServiceProvider serviceProvider) 
		=> serviceProvider.GetRequiredService<ICmdRegistry>().RememberTransientServiceCommandsByName(serviceProvider);
}
