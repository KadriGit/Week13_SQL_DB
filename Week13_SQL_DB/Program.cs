using System.Data.SQLite;

ReadData(CreateConnection());
AddCustomer(CreateConnection());

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

static void AddCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;

    string fName = "Harry";
    string lName = "Potter";
    string dob = "07-31-1980";

    command = myConnection.CreateCommand();
    command.CommandText = $"INSERT INTO customer(fisrtName, lastName, dateOfBirth) VALUES ('{fName}','{lName}','{dob}')";


    int rowInserted = command.ExecuteNonQuery();

    Console.Clear();
    Console.WriteLine($"Rows insterted: {rowInserted}");

    ReadData(myConnection);

    myConnection.Close();

}

