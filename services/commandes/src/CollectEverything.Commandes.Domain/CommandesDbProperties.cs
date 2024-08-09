namespace CollectEverything.Commandes;

public static class CommandesDbProperties
{
    public static string DbTablePrefix { get; set; } = "Commandes";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Commandes";
}
