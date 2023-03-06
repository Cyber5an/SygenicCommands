# SygenicCommands 1.0.1

## C# library implementing plugin system.

A command is some code that can be executed, has its own name and can be checked for ability to execute.
To use SygenicCommand

1. Append service with .TryAddSygenicCommands() on IServiceCollection instance
2. Run .UseSygenicCommands() on IServiceProvider instance

SygenicCommands provides a singleton ICmdRegistry which can return ICmd instances by name

## There are 3 ways to create a command.

1. Implement ICmd interface, so the implementation has its Name, bool CanBeExecutedAsync and ExecuteAsync, with no context
2. Implement ICmd<CONTEXT> interface with a class acting as CONTEXT, so the implementation has two methods more - CanBeExecutedAsync(CONTEXT ctx)
and ExecuteAsync(CONTEXT ctx).
3. Use ICmdRegistry.RegisterLambdaCmd(...) and provide name, func to check if command can be executed and action called on commmand execution.

## Some additional notes

1. ICmd and ICmd<CONTEXT> implementations are registered to IServiceCollection as transients.
2. ICmd<CONTEXT> inherits ICmd and registering lambda cmd within ICmdRegistry also gives ICmd instance, so every command is an ICmd.
