using UnityEngine;
using UnityEngine.EventSystems;

// summary
// A script, that moves player by rotating any object on the scene
// summary
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PointerDownHandler _pointerDownHandler;
    [SerializeField] private Transform _objectToRotate;
    [SerializeField] private float _rotationSpeed = 300f;
    private int _direction = -1; // 1 - counterclockwise, -1 - clockwise

    private void Awake()
    {
        _pointerDownHandler.Clicked.AddListener(ChangeDirection);
        _player.Dead.AddListener(StopRotating);
    }

    private void Update()
    {
        _objectToRotate.Rotate(0f, 0f, _direction * _rotationSpeed * Time.deltaTime);
    }

    private void ChangeDirection(PointerEventData eventData)
    {
        if(_direction == -1)
        {
            _direction = 1;
        }
        else
        {
            _direction = -1;
        }
    }

    private void StopRotating()
    {
        _direction = 0;
    }
}
