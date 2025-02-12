using UnityEngine;

public class ConnectingUI : MonoBehaviour
{
    private void Start() {
        KitchenGameMultiPlayer.Instance.OnTryingToJoinGame += KitchenGameMultiPlayer_OnTryingToJoinGame;
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame += KitchenGameMultiplayer_OnFailedToJoinGame;
        Hide();
    }

    private void KitchenGameMultiplayer_OnFailedToJoinGame(object sender, System.EventArgs e) {
        Hide();
    }

    private void KitchenGameMultiPlayer_OnTryingToJoinGame(object sender, System.EventArgs e) {
        Show();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);

    }
    private void OnDestroy() {
        KitchenGameMultiPlayer.Instance.OnTryingToJoinGame -= KitchenGameMultiPlayer_OnTryingToJoinGame;
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame -= KitchenGameMultiplayer_OnFailedToJoinGame;
    }
}
