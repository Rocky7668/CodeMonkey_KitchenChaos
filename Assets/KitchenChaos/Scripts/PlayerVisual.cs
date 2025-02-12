using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer headMeshRendered;
    [SerializeField] private MeshRenderer bodyMeshRendered;

    private Material material;

    private void Awake() {
        material = new Material(headMeshRendered.material);

        headMeshRendered.material = material;
        bodyMeshRendered.material = material;
    }

    public void SetPlayerColor(Color color) {
        material.color = color;
    }
}
