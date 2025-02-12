using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CharacterSelectReady : NetworkBehaviour
{
    public static CharacterSelectReady Instance { get; private set; }

    private Dictionary<ulong, bool> playerReadyDictonary;

    public event EventHandler OnReadyChanged;

    private void Awake() {
        playerReadyDictonary = new Dictionary<ulong, bool>();
        Instance = this;
    }
    
    public void SetPlayerReady() {
        SetPlayerReadyServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default) {

        SetPlayerReadyClientRpc(serverRpcParams.Receive.SenderClientId);

        playerReadyDictonary[serverRpcParams.Receive.SenderClientId] = true;

        bool allClintReady = true;
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds) {
            if (!playerReadyDictonary.ContainsKey(clientId) || !playerReadyDictonary[clientId]) {
                //This Player is Not Ready
                allClintReady = false;
                break;
            }
        }

        if (allClintReady) {
            Loader.LoadNetwork(Loader.Scene.GameScene);
        }
    }

    [ClientRpc]
    private void SetPlayerReadyClientRpc(ulong clietId) {
        playerReadyDictonary[clietId] = true;

        OnReadyChanged?.Invoke(this, EventArgs.Empty);
    }


    public bool IsPlayerReady(ulong clientId) {
        return playerReadyDictonary[clientId] && playerReadyDictonary.ContainsKey(clientId);
    }
}
