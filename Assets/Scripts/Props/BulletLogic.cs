using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class BulletLogic : NetworkBehaviour
{
    public float Damage;
    public float TimeToDestroy;
    public float Speed;

    public Vector2 Direction;

    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Direction.y * 90));
        GetComponent<Rigidbody2D>().AddForce(Direction * Speed, ForceMode2D.Impulse);
        StartCoroutine(BulletDestroy());
    }

    IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(TimeToDestroy);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBody"))
            collision.transform.parent.GetComponent<CharacterStats>().HP.Value -= Damage;

        if (!collision.CompareTag("Bullet"))
            Destroy(gameObject);
            
    }
}
