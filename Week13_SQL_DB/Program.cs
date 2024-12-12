using System.Data.SQLite;

CreateConnection();

static SQLiteConnection CreateConnection()
{
    SQLiteConnection connection = new SQLiteConnection("Data Source=mydb.db; version=3;new=True;Compress=True;");

    try
    {
        connection.Open();
        Console.WriteLine("Connection established");
    }
    catch
    {
        Console.WriteLine("DB Connection failed");
    }

    return connection;
}

