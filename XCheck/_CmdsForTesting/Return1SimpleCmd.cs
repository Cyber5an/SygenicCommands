namespace XCheck;

internal class Return1SimpleCmd : ICmd
{
	public string Name => "1";
	public Task<bool> CanExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(true);
	public Task ExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(1);
}
