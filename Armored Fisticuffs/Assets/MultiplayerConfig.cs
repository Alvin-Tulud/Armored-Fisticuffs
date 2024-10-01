using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerConfig : MonoBehaviour
{
    List<int> playerId = new List<int>();
    public GameObject EndScreen;

    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);
        playerId.Add(playerInput.playerIndex);
    }

    private void Update()
    {
        if (GameObject.Find("EndScreen") != null)
        {
            EndScreen = GameObject.Find("EndScreen");
            this.gameObject.GetComponent<PlayerInputManager>().DisableJoining();
        }
        if (playerId.Count == this.gameObject.GetComponent<PlayerInputManager>().maxPlayerCount)//disable respawns
        {
            this.gameObject.GetComponent<PlayerInputManager>().DisableJoining();
        }
    }

    void OnPlayerLeft(PlayerInput playerInput)
    {
        Debug.Log("you absolute loser howd you die");
    }
}
