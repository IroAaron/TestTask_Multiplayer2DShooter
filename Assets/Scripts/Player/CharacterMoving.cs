using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class CharacterMoving : NetworkBehaviour
{
    private float _speed = 3;

    private GameUIJoystick _joystick;
    public NetworkVariable<Vector2> _direction = new NetworkVariable<Vector2>(new Vector2(0,0));

    private void Start()
    {
        _speed = GetComponent<CharacterStats>().Speed.Value;
        _joystick = FindObjectOfType<GameUIJoystick>();
    }

    private void Update()
    {
        _direction.Value = GetInputDirection();
        GetComponent<Rigidbody2D>().velocity = _speed * _direction.Value;
    }

    public Vector2 GetInputDirection()
    {
        return new Vector2(_joystick.Horizontal(), _joystick.Vertical());
    }
}
