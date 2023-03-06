namespace SygenicCommands;

[Serializable]
internal class TypeNotImplementingICmdException : Exception
{
	private readonly string? name;
	private readonly Type type;

	public TypeNotImplementingICmdException(Type type)
	{
		this.type = type;
	}

	public TypeNotImplementingICmdException(string name, Type type)
	{
		this.name = name;
		this.type = type;
	}
}