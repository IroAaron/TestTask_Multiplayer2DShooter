using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : NetworkBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] private TextMeshProUGUI CoinCounter;

    private GameObject _player;

    void Update()
    {
        if(_player == null)
        {
            _player = FindObjectOfType<CharacterStats>().gameObject;
        }
        else
        {
            HealthBar.value = _player.GetComponent<CharacterStats>().HP.Value;
            CoinCounter.text = _player.GetComponent<CharacterBag>().Coin.ToString();
        }
    }

    public void LobbyExit()
    {
        SceneManager.LoadScene("Lobby");
    }
}
