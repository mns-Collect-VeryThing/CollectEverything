namespace CollectEverything.Shops;

public static class ShopsDbProperties
{
    public static string DbTablePrefix { get; set; } = "Shops";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Shops";
}
