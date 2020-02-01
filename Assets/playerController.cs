using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private ItemControl playerControls;

    public PlayerStates PlayerState = PlayerStates.PLAYER;

    public enum PlayerStates
    {
        PLAYER = 0, CONTROL0 = 1
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerState)
        {
            case PlayerStates.PLAYER:
                playerControls.ControlPart();
                break;
            case PlayerStates.CONTROL0:
                break;
        }
    }
}
