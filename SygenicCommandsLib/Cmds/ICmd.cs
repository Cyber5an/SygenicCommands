namespace SygenicCommandsLib;

public interface ICmd
{
	string Name { get; }

	Task<bool> CanExecuteAsync(CancellationToken cancellationToken);

	Task ExecuteAsync(CancellationToken cancellationToken);
}

public interface ICmd<CONTEXT> : ICmd where CONTEXT: notnull
{
	Task<bool> CanExecuteAsync(CONTEXT context, CancellationToken cancellationToken);

	Task ExecuteAsync(CONTEXT context, CancellationToken cancellationToken);
}