using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] private int CoinValue;

    private void Start()
    {
        CoinValue = Random.Range(1, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterBag>().Coin += CoinValue;
            Destroy(gameObject);
        }
    }
}
