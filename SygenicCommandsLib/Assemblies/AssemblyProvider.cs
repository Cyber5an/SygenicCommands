namespace SygenicCommandsLib;

public sealed class AssemblyProvider : ItemsProvider<Assembly>, IAssemblyProvider
{
    public void PushCurrentDomainAssemblies() => Push(AppDomain.CurrentDomain.GetAssemblies());
}
