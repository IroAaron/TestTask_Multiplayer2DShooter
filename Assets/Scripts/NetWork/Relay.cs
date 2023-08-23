using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.UI;

public class Relay : MonoBehaviour
{
    public TextMeshProUGUI proUGUI;
    public TMP_InputField inputField;

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in" + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
     
    public async void CreateRelay()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);

            //попробовать ввести свой код ретранслятора
            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            proUGUI.text = joinCode;

            RelayServerData serverData = new RelayServerData(allocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(serverData);

            NetworkManager.Singleton.StartHost();

            GetComponent<CameraFollow>().target = FindObjectOfType<CharacterStats>().transform;
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }
     

    public async void JoinRelay(string joinCode)
    {
        if(inputField.text != null)
        {
            joinCode = inputField.text;
        }
        try
        {
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData serverData = new RelayServerData(joinAllocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(serverData);

            NetworkManager.Singleton.StartClient();

            GetComponent<CameraFollow>().target = FindObjectOfType<CharacterStats>().transform;
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }
}
