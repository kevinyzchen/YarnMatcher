using Godot;
using Color = System.Drawing.Color;

namespace YarnMatcher;

public partial class Main : Node
{
    private YarnDatabase _database = new YarnDatabase();
    public override void _Ready()
    {
        base._Ready();
        _database.CreateDatabase();
        _database.AddToDatabase(1f, Color.Purple);
        _database.AddToDatabase(3f, Color.Red);
        _database.AddToDatabase(4f, Color.Azure);
        _database.ReadFromDatabase();
    }
}