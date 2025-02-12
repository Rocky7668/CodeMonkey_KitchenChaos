using UnityEngine;
using UnityEngine.UI;

public class TestingLobbyUI : MonoBehaviour
{
    [SerializeField] private Button createGameButton;
    [SerializeField] private Button joinGameButton;

    private void Awake() {
        createGameButton.onClick.AddListener(delegate {
            KitchenGameMultiPlayer.Instance.StartHost();
            Loader.LoadNetwork(Loader.Scene.CharacterSelectScene);
        });

        joinGameButton.onClick.AddListener(delegate {
            KitchenGameMultiPlayer.Instance.StartClient();
        });
    }
}
