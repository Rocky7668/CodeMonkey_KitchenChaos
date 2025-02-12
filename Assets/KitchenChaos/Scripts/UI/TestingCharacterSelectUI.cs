using UnityEngine;
using UnityEngine.UI;

public class TestingCharacterSelectUI : MonoBehaviour
{
    [SerializeField] private Button readyButton;

    private void Awake() {
        readyButton.onClick.AddListener(delegate {
            CharacterSelectReady.Instance.SetPlayerReady();
        });
    }
}
