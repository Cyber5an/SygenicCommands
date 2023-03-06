namespace SygenicCommandsLib;

internal sealed class CmdRegistry : ICmdRegistry
{
	#region ctor DI
	private readonly IImplementationsProvider implementationsProvider;

	public CmdRegistry(IImplementationsProvider implementationsProvider)
	{
		this.implementationsProvider = implementationsProvider;
	}
	#endregion

	/// <summary>
	/// Value (byte) is not used. There is no ConcurrentHashSet
	/// </summary>
	private readonly ConcurrentDictionary<Type, byte> FoundTransientServiceCmds = new();

	private readonly ConcurrentDictionary<string, LambdaCmd> LambdaSimpleCmds = new();

	private readonly ConcurrentDictionary<string, Type> NameToCmdType = new();

	public void FindAndRegisterCmdsAsTransients(IServiceCollection services)
	{
		var types = implementationsProvider.FindConcreteImplementations(typeof(ICmd));
		foreach (var type in types) 
		{ 
			services.TryAddTransient(type);
			FoundTransientServiceCmds[type] = 0;
		}
	}

	public void RegisterLambdaCmd(string name, Func<bool> canExecute, Action execute) 
		=> LambdaSimpleCmds[name] = new LambdaCmd { Name = name, CanExecuteLambda = canExecute, ExecuteLambda = execute };

	private IServiceProvider? serviceProvider;

	public void RememberTransientServiceCommandsByName(IServiceProvider serviceProvider)
	{
		this.serviceProvider = serviceProvider;
		foreach (var type in FoundTransientServiceCmds.Keys)
		{
			var cmd = serviceProvider.CreateScope().ServiceProvider.GetRequiredService(type) as ICmd ?? throw new TypeNotImplementingICmdException(type);
			NameToCmdType[cmd.Name] = type;
		}
	}

	public ICmd GetCmd(string name)
	{
		if (serviceProvider is null) throw new Exception($"Please init cmdRegistry by running {nameof(SygenicCommandsLib)}.{nameof(Extensions)}.{nameof(Extensions.UseSygenicCommands)}");

		if (LambdaSimpleCmds.TryGetValue(name, out var value)) return value;

		if (NameToCmdType.TryGetValue(name, out var type))
		{
			return serviceProvider.GetRequiredService(type) as ICmd ?? throw new TypeNotImplementingICmdException(name, type);
		}

		throw new CmdNotRegisteredException(name);
	}

	public IEnumerable<ICmd> GetCmds(string commaDelimitedCmdNames)
	{
		var ret = new List<ICmd>();
		foreach (var token in commaDelimitedCmdNames.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
		{
			ret.Add(GetCmd(token));
		}
		return ret;
	}
}
