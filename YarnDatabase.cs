using System.Data.SQLite;
using Godot;
using Color = System.Drawing.Color;

public class YarnDatabase
{
    private string databasePath = "res://database";

    public void CreateDatabase()
    {
        SQLiteConnection.CreateFile("YarnDataBase.sqlite");
        SQLiteConnection connection = new SQLiteConnection("Data Source=YarnDataBase.sqlite;Version=3;");
        connection.Open();
        string createTableSQL = "CREATE TABLE yarn (id INTEGER PRIMARY KEY, yardage INTEGER, color TEXT)";
        SQLiteCommand createTableCommand = new SQLiteCommand(createTableSQL, connection);
        createTableCommand.ExecuteNonQuery();
        connection.Close();
    }

    public void AddToDatabase(float yardage, Color color)
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=YarnDataBase.sqlite;Version=3;");
        connection.Open();
        string insertDataSQL = "INSERT INTO yarn (yardage, color) VALUES (@yardage, @color)";
        SQLiteCommand insertDataCommand = new SQLiteCommand(insertDataSQL, connection);
        insertDataCommand.Parameters.AddWithValue("@yardage", yardage);
        insertDataCommand.Parameters.AddWithValue("@color", color);
        insertDataCommand.ExecuteNonQuery();
        connection.Close();

    }

    public void ReadFromDatabase()
    {
        string selectDataSQL = "SELECT * FROM yarn WHERE yardage > @minYardage";
        SQLiteConnection connection = new SQLiteConnection("Data Source=YarnDataBase.sqlite;Version=3;");
        connection.Open();
        SQLiteCommand selectDataCommand = new SQLiteCommand(selectDataSQL, connection);
        selectDataCommand.Parameters.AddWithValue("@minYardage", 0);
        SQLiteDataReader reader = selectDataCommand.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            int yardage = reader.GetInt32(1);
            string color = reader.GetString(2);
            GD.Print("Yarn ID: {0}, Yardage: {1}, Color: {2}", id, yardage, color);
        }
        reader.Close();
        connection.Close();
    }
    
}
