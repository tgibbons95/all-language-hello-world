using Microsoft.Data.Sqlite;

public class HelloWorldSql : IHelloWorld
{
    public string GetHelloWorld()
    {
        var connection = new SqliteConnection("Data Source=dependencies/Sql/HelloWorld.db");

        try
        {
            // Open connection before query
            connection.Open();

            // Create query command
            var command = connection.CreateCommand();
            command.CommandText = File.ReadAllText("dependencies/Sql/HelloWorldQuery.sql");
            var result = command.ExecuteScalar();

            // Close connection before returning
            connection?.Close();

            return result as string ?? "Error: Sql";
        }
        catch
        {
            // Close connection before returning
            connection?.Close();

            return "Error: Sql";
        }
    }

    public bool IsEnabled() { return true; }
}
