using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    ItemControl playerControls;

    public enum PlayerStates
    {
        PLAYER = 0, CONTROL0 = 1
    }

    public PlayerStates PlayerState { get; set; } = PlayerStates.PLAYER;

    void Start()
    {
        switch (PlayerState)
        {
            case PlayerStates.PLAYER:

                break;
            case PlayerStates.CONTROL0:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
