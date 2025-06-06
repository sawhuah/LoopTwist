public interface IObstacle
{
    public Player Player { get; set; }
    public ScoreCounter ScoreCounter { get; set; }

    public void PerformAction();
}
