using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public Sprite S1;
    public Sprite S2;
    public Sprite S3;
    public Sprite S4;
    public Sprite S5;
    public Sprite S6;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControls player;
        player = gameObject.GetComponent<PlayerControls>();
        if (player.playerNumber == 0)
        {
            GetComponent<SpriteRenderer>().sprite = S1;
        }
        else if (player.playerNumber == 1)
        {
            GetComponent<SpriteRenderer>().sprite = S2;
        }
        else if (player.playerNumber == 2)
        {
            GetComponent<SpriteRenderer>().sprite = S3;
        }
        else if (player.playerNumber == 3)
        {
            GetComponent<SpriteRenderer>().sprite = S4;
        }
        else if (player.playerNumber == 4)
        {
            GetComponent<SpriteRenderer>().sprite = S5;
        }
        else{
            GetComponent<SpriteRenderer>().sprite = S6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
