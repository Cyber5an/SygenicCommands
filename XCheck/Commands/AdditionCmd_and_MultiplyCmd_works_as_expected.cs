namespace Commands;

public class AdditionCmd_and_MultiplyCmd_works_as_expected
{
	[Fact]
	public async Task _()
	{
		var cancellationToken = CancellationToken.None;
		var add = new AdditionCmd();

		Assert.True(await add.CanExecuteAsync(cancellationToken));
		await add.ExecuteAsync(cancellationToken);

		var aContext = new AdditionContext{ input = new int[] { 1, 2, 3 } };
		Assert.True(await add.CanExecuteAsync(aContext, cancellationToken));
		await add.ExecuteAsync(aContext, cancellationToken);
		Assert.Equal(6, aContext.output);
		

		var multiply = new MultiplyCmd();
		Assert.True(await multiply.CanExecuteAsync(cancellationToken));
		await multiply.ExecuteAsync(cancellationToken);

		var mContext = new MultiplyContex { input = new int[] { 2, 3, 4 } };
		Assert.True(await multiply.CanExecuteAsync(mContext, cancellationToken));
		await multiply.ExecuteAsync(mContext, cancellationToken);
		Assert.Equal(24, mContext.output);
	}
}