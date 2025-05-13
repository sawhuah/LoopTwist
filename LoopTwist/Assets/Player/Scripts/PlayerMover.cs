using UnityEditor.Experimental.GraphView;
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
        _pointerDownHandler.Pressed.AddListener(ChangeDirection);
        _player.Dead.AddListener(StopRotating);
    }

    private void Update()
    {
        if(_player.IsDead == false)
        {
            _objectToRotate.Rotate(0f, 0f, _direction * _rotationSpeed * Time.deltaTime);
        }
    }

    private void ChangeDirection() =>
        _direction = _direction == 1 ? -1 : 1;

    private void StopRotating() =>
        _rotationSpeed = 0;
}
