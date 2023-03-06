namespace SygenicCommands;

[Serializable]
internal class CmdNotRegisteredException : Exception
{
    public CmdNotRegisteredException()
    {
    }

    public CmdNotRegisteredException(string? message) : base(message)
    {
    }

    public CmdNotRegisteredException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CmdNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}