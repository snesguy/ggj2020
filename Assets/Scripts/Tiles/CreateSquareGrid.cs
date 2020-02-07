using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSquareGrid : MonoBehaviour
{
    public GameObject square;
    public int width = 0;
    public int height = 0;
    public float spacing = .15f;
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid(int width, int height)
    {
        Vector3 location = new Vector3(0, 0, 0);
        for (location.y = 0; location.y < height; location.y += spacing)
        {
            for (location.x = 0; location.x < width; location.x += spacing)
            {
                GameObject.Instantiate(square, location, Quaternion.identity);
            }
        }
    }
}
