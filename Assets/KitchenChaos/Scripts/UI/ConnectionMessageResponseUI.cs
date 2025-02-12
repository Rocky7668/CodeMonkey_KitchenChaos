using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionMessageResponseUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;
    private void Awake() {
        closeButton.onClick.AddListener(() => Hide());

    }

    private void Start() {
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame += KitchenGameMultiplayer_OnFailedToJoinGame;
        
        Hide();
    }

    private void KitchenGameMultiplayer_OnFailedToJoinGame(object sender, System.EventArgs e) {
        Show();

        messageText.text = NetworkManager.Singleton.DisconnectReason;

        if(messageText.text == null) {
            messageText.text = "Failed to Connect";
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);

    }

    private void OnDestroy() {
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame -= KitchenGameMultiplayer_OnFailedToJoinGame;
    }
}
