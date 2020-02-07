using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCount : MonoBehaviour
{
    public int count;

    // Start is called before the first frame update
    void Start () {
        count = 0;
    }

    public int getCount () {
        return count;
    }

    public void incrementCount () {
        count++;
    }
}
