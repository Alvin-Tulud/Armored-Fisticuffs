using UnityEngine;
using UnityEngine.InputSystem;

public class PInManager : MonoBehaviour
{
    public PlayerInputManager inputManager;

    void OnPlayerJoined(PlayerInput input)
    {
        Debug.Log(input.devices[input.devices.Count - 1].name);
        Debug.Log(input.devices[0].name);
        Debug.Log(input.devices.Count);

        PlayerInput pin = new PlayerInput();
    }
}
