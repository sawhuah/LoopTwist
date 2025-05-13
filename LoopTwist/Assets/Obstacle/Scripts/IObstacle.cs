public interface IObstacle
{
    public Player Player { get; set; }

    public void PerformAction();
}
