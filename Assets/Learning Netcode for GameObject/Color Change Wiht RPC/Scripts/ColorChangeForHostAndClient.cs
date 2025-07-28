using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeForHostAndClient : NetworkBehaviour
{
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _clientButton;
    [SerializeField] private GameObject _cubes;

    private void Awake()
    {
        _hostButton.onClick.AddListener(ColorChangeHostRpc);
        _clientButton.onClick.AddListener(ColorChangeClientRpc);
    }

    public override void OnNetworkSpawn()
    {
        if (IsHost)
        {
            _hostButton.gameObject.SetActive(true);

            if (_clientButton.gameObject.activeSelf)
            {
                _clientButton.gameObject.SetActive(false);
            }
        }
        else if (IsClient)
        {
            _clientButton.gameObject.SetActive(true);

            if (_hostButton.gameObject.activeSelf)
            {
                _clientButton.gameObject.SetActive(false);
            }
        }
    }

    [Rpc(SendTo.Server)]
    private void ColorChangeHostRpc()
    {
        Renderer boxMatarial = _cubes.GetComponent<Renderer>();
        boxMatarial.material.color = Color.green;
        _cubes.GetComponent<Renderer>().material.color = Color.green;
        CangeColorRpc(Color.green);
    }

    [Rpc(SendTo.Server)]
    private void ColorChangeClientRpc()
    {
        Renderer boxMatarial = _cubes.GetComponent<Renderer>();
        boxMatarial.material.color = Color.blue;
        _cubes.GetComponent<Renderer>().material.color = Color.blue;
        CangeColorRpc(Color.blue);
    }

    [Rpc(SendTo.ClientsAndHost)]
    private void CangeColorRpc(Color color)
    {
        _cubes.GetComponent<Renderer>().material.color = color;
    }
}
