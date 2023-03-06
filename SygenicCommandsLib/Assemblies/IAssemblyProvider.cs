namespace SygenicCommandsLib;

public interface IAssemblyProvider : IItemsProvider<Assembly>
{
    void PushCurrentDomainAssemblies();
}