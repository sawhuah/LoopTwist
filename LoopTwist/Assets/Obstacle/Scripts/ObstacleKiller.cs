using UnityEngine;

public class ObstacleKiller : MonoBehaviour, IObstacle
{
    public Player Player { get; set; }

    public void PerformAction()
    {
        Player.TakeDamage(Player.Health);
    }
}
