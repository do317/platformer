using Godot;

public partial class Mover : Node2D
{
    [Export] public float Speed = 200.0f;
    // 200/60 = 3.33333px / s
    // 200/30 = 6.66667px / s

    public override void _PhysicsProcess(double delta)
    {
        // GD.Print($"Physics: {delta:F4}");
        Position += new Vector2(Speed, 0) * (float)delta;
        if (Position.X > 1200)
            Position = new Vector2(80, Position.Y);
    }
    // public override void _Process(double delta)
    // {
    //     GD.Print($"Process: {delta:F4}");
    // }
}