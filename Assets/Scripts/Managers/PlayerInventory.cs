using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool onResourcePile = false;
    public bool onUraniumPile = false;

    public bool handsFull;
    public int uranium;
    public int gear;

    public bool tryPickup = false;
    // Start is called before the first frame update
    void Start()
    {
        handsFull = false;
        gear = 0;
        uranium = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tryPickup)
        {
            if(onResourcePile)
            {
                
            }
            else if(onUraniumPile)
            {

            }

            if (uranium > 0 || gear > 0)
            {
                handsFull = true;
            }
            else
            {
                handsFull = false;
            }
        }

    }
    public int getGear()
    {
        return gear;
    }
    public void addGear(int newGear)
    {

        gear += newGear;
    }
    public void useGear(int gearUsed)
    {

        gear -= gearUsed;
    }
    public int getUranium()
    {
        return uranium;
    }
    public void addUranium(int newUranium)
    {

        uranium += newUranium;
    }
    public void useUranium(int uraniumUsed)
    {

        uranium += uraniumUsed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ResourcePile"))
        {
            onResourcePile = true;
        }
        else if (other.gameObject.CompareTag("UraniumPile"))
        {
            onUraniumPile = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ResourcePile"))
        {
            onResourcePile = false;
        }
        else if (other.gameObject.CompareTag("UraniumPile"))
        {
            onUraniumPile = false;
        }
    }
}
