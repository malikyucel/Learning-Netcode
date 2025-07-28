using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HostClientConnect : NetworkBehaviour
{
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _clientButton;
    [SerializeField] private GameObject _colorChange;

    private void Awake()
    {
        _hostButton.onClick.AddListener(HostButton);
        _clientButton.onClick.AddListener(ClientButton);
    }

    private void HostButton()
    {
        NetworkManager.Singleton.StartHost();
        _colorChange.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("Host connected");
    }

    private void ClientButton()
    {
        NetworkManager.Singleton.StartClient();
        _colorChange.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("Client connected");
    }
}
