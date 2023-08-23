using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField] private float Force;
    [SerializeField] private float ShootDelay;

    public Vector2 BulletDirection { get; private set; } = new Vector2(0, -1);

    private Vector2 _direction;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        _direction = GetComponent<CharacterMoving>().GetInputDirection();

        if (GetComponent<CharacterMoving>().GetInputDirection() != new Vector2(0, 0))
        {
            BulletDirection = new Vector2(_direction.x == 0 ? 0 : _direction.x / Math.Abs(_direction.x),
               _direction.y == 0 ? 0 : _direction.y / Math.Abs(_direction.y));
        }
    }

    public void BulletInstantiator(GameObject gameObject, Vector2 direction)
    {
        gameObject.transform.position = (Vector2)transform.position + direction;
        gameObject.GetComponent<BulletLogic>().Direction = direction;
        gameObject.GetComponent<BulletLogic>().Damage += GetComponent<CharacterStats>().BonusDamage.Value;
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShootDelay);

            BulletInstantiator(Instantiate(Bullet), BulletDirection);
            GetComponent<CharacterMoving>().GetInputDirection();
        }
    }
}
