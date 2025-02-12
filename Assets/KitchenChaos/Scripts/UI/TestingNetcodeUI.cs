using System.Transactions;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;


    private void Awake() {
        startHostButton.onClick.AddListener(delegate {
            KitchenGameMultiPlayer.Instance.StartHost();
            Hide();
        });

        startClientButton.onClick.AddListener(delegate {
            KitchenGameMultiPlayer.Instance.StartClient();

            Hide();
        });
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
