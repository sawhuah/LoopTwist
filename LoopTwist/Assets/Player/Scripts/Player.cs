using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent Dead;
    public int Health { get; private set; } = 1;
    public bool IsDead { get; private set; } = false;

    [SerializeField] private AudioSource _bonusCollectingSound;
    [SerializeField] private TrailRenderer[] _trailRenderers;

    private void Update()
    {
        for(int i = 0; i <  _trailRenderers.Length; i++)
        {
            _trailRenderers[i].transform.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IObstacle>() != null)
        {
            collision.GetComponent<IObstacle>().PerformAction();
            if(collision.GetComponent<ObstacleHelper>() != null)
            {
                _bonusCollectingSound.Play();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if(Health > amount)
        {
            Health -= amount;
        }
        else
        {
            Dead?.Invoke();
            Destroy(gameObject);
            IsDead = true;
        }
    }
}
