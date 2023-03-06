namespace SygenicCommands;

public interface IAssemblyProvider : IItemsProvider<Assembly>
{
    void PushCurrentDomainAssemblies();
}