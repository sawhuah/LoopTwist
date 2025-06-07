using UnityEngine;

public class DeathView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _deathParticle;
    [SerializeField] private AudioSource _deathSound;

    private void Start()
    {
        _player.Dead.AddListener(OnDeath);
    }

    private void Update()
    {
        if(_player != null)
        {
            transform.position = _player.transform.position;
        }
    }

    private void OnDeath()
    {
        Instantiate(_deathParticle, transform);
        _deathSound.Play();
    }
}
