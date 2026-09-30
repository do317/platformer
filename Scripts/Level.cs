using Godot;

public partial class Level : Node2D
{
    [Export] public string GameTitle = "Bākas gaisma";
    [Export] public string Mission = "Atrodi dzelteno atslēgu un sasniedz zaļo bāku. Izvairies no sarkanās bedres!";
    [Export] public string WinText = "Bāka atkal spīd. Kuģi var atrast mājas!";
    [Export] public string LoseText = "Ceļojums pārtrūka. Mēģini vēlreiz!";
    [Export] public string LockedText = "Vispirms atrodi dzelteno atslēgu augšējā platformā.";

    private Player player;
    private Label status;
    private Label message;
    public bool GameEnded { get; private set; } = false;

    public override void _Ready()
    {
        player = GetNode<Player>("Player");
        status = GetNode<Label>("HUD/Status");
        message = GetNode<Label>("HUD/Message");
        GetNode<Label>("HUD/Instructions").Text =
            $"{GameTitle} | A/D vai ←/→: kustība | Space: lēciens | R: sākt no jauna";
        message.Text = Mission;
        GetNode<Area2D>("Finish").BodyEntered += OnFinishEntered;
        GetNode<Area2D>("Hazard").BodyEntered += OnHazardEntered;
        GetNode<Area2D>("Hazard2").BodyEntered += OnHazardEntered;
        UpdateHud();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("restart"))
        {
            GetTree().ReloadCurrentScene();
            return;
        }

        if (!GameEnded && player.GlobalPosition.Y > 800)
            EndGame(false);

        UpdateHud();
    }

    private void UpdateHud()
    {
        string keyStatus = player.HasKey ? "ir" : "nav";
        status.Text = $"Punkti: {player.Score} | Atslēga: {keyStatus}";
    }

    private void OnFinishEntered(Node2D body)
    {
        if (body != player || GameEnded) return;

        if (player.HasKey)
            EndGame(true);
        else
            message.Text = LockedText;
    }

    private void OnHazardEntered(Node2D body)
    {
        if (body == player) EndGame(false);
    }

    private void EndGame(bool won)
    {
        if (GameEnded) return;
        GameEnded = true;
        player.IsActive = false;
        player.Velocity = Vector2.Zero;
        message.Text = (won ? WinText : LoseText) + " | Nospied R, lai spēlētu vēlreiz.";
        UpdateHud();
    }
}