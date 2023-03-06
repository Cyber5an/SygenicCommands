namespace SygenicCommandsLib;

/// <summary>
/// Registered as Singleton in SygenicCommandsLib.Extensions.TryAddSygenicCommands
/// </summary>
public interface ICmdRegistry
{
	/// <summary>
	/// Called during registration in SygenicCommandsLib.Extensions.TryAddSygenicCommands
	/// </summary>
	/// <param name="services"></param>
	void FindAndRegisterCmdsAsTransients(IServiceCollection services);

	/// <summary>
	/// To be called during runtime
	/// </summary>
	/// <param name="name"></param>
	/// <param name="canExecute"></param>
	/// <param name="execute"></param>
	void RegisterLambdaCmd(string name, Func<bool> canExecute, Action execute);


	/// <summary>
	/// Called after services are built in SygenicCommandsLib.Extensions.UseSygenicCommands
	/// </summary>
	void RememberTransientServiceCommandsByName(IServiceProvider serviceProvider);

	ICmd GetCmd(string name);

	IEnumerable<ICmd> GetCmds(string commaDelimitedCmdNames);
}