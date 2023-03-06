namespace CommandRegistry_;

public class RegisterCmdsAsTransients_
{
	[Fact]
	public void _()
	{
		X.Services.GetRequiredService<Return1SimpleCmd>();
		X.Services.GetRequiredService<AdditionCmd>();
	}
}
