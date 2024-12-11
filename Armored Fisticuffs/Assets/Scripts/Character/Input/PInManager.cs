using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PInManager : MonoBehaviour
{
    public PlayerInputManager inputManager;
    private GameObject[] spawnLoc;
    private GameObject p1;
    private Vector3 p1Facing;

    private GameObject p2;
    private Vector3 p2Facing;

    private void Start()
    {
        spawnLoc = GameObject.FindGameObjectsWithTag("SpawnLoc");
    }

    void OnPlayerJoined(PlayerInput input)
    {
        Debug.Log(input.devices[input.devices.Count - 1].name);
        Debug.Log(input.devices[0].name);
        Debug.Log(input.devices.Count);

        if (p1 == null)
        {
            p1 = input.gameObject;
            p1.transform.position = spawnLoc[1].transform.position;
        }
        else
        {
            p2 = input.gameObject;
            p2.transform.position = spawnLoc[0].transform.position;
            p2.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
    }

    private void Update()
    {
        
    }
}
