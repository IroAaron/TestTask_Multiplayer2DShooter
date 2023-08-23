using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManagerUI : NetworkBehaviour
{
    //[SerializeField] private Button _hostButton;
    //[SerializeField] private Button _clientButton;

    //private void Awake()
    //{
    //    _hostButton.onClick.AddListener(() =>
    //    {
    //        NetworkManager.Singleton.StartHost();
    //        SceneManager.LoadScene("Game");
    //        NetworkManager.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    //    });

    //    _clientButton.onClick.AddListener(() =>
    //    {
    //        NetworkManager.Singleton.StartClient();
    //        SceneManager.LoadScene("Game");
    //        NetworkManager.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    //    });
    //}

    public void CreateTheHostServer()
    {
        NetworkManager.Singleton.StartHost();
        SceneManager.LoadScene("Game");
        NetworkManager.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void JoinToTheHostServer()
    {
        NetworkManager.Singleton.StartClient();
        SceneManager.LoadScene("Game");
        NetworkManager.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
