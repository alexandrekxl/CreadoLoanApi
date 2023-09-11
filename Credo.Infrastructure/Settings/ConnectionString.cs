namespace Credo.Infrastructure.Settings
{
    public class ConnectionString
    {
        public static string SectionName { get; } = "ConnectionString";
        public string CredoConnection { get; init; } = null!;
        
    }
}
