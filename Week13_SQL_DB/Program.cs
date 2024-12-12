using System.Data.SQLite;

ReadData(CreateConnection());

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

static void ReadData(SQLiteConnection myConnection)
{
    SQLiteDataReader read;
    SQLiteCommand command;

    command = myConnection.CreateCommand();
    command.CommandText = "SELECT * FROM customer";

    read = command.ExecuteReader();

    while (read.Read())
    {
        string fName = read.GetString(0);
        string lName = read.GetString(1);
        string dob = read.GetString(2);

        Console.WriteLine($"Full name: {fName} {lName}; DoB: {dob}");
    }

    myConnection.Close();
}

