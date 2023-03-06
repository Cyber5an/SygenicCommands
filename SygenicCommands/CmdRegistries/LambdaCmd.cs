namespace SygenicCommands;

public class LambdaCmd : ICmd
{
	public required string Name { get; init; }
	public required Func<bool> CanExecuteLambda { get; init; }
	public required Action ExecuteLambda { get; init; }

	public Task<bool> CanExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(CanExecuteLambda());

	public Task ExecuteAsync(CancellationToken cancellationToken)
	{
		ExecuteLambda();
		return Task.CompletedTask;
	}
}
