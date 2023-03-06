namespace XCheck.CmdRegistry_;

public class GetCmd_
{
	[Fact]
	public void _()
	{
		var cmdRegistry = X.Services.GetRequiredService<ICmdRegistry>();
		var addition = cmdRegistry.GetCmd("1");
		Assert.Throws<CmdNotRegisteredException>(() => cmdRegistry.GetCmd("xxx"));
	}
}
