using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResorceContence : MonoBehaviour
{
    public int resorseCount;
    // Start is called before the first frame update
    void Start()
    {     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int get() {
        return resorseCount;
    }
    public void set(int pickedUp) {
        resorseCount -= pickedUp;
        if(resorseCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
