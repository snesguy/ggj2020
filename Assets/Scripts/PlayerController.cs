using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private ItemControl playerControls;

    [SerializeField]
    private ItemControl player2Controls;

    [SerializeField]
    private ItemControl mainWeapon;

    public PlayerStates PlayerState = PlayerStates.PLAYER;

    public enum PlayerStates
    {
        PLAYER = 0, CONTROL0 = 1, MAINWEAPON = 2
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
                player2Controls.ControlPart();
                break;
            case PlayerStates.MAINWEAPON:
                mainWeapon.ControlPart();
                break;
        }
    }
}
