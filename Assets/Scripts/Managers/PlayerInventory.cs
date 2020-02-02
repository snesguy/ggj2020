using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool handsFull;
    public int uranium;
    public int gear;
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

        if(uranium > 0 || gear > 0)
        {
            handsFull = true;
        }
        else
        {
            handsFull = false;
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
}
