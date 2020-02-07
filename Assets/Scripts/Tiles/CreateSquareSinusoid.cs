using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSquareSinusoid : MonoBehaviour
{

    public GameObject square;
    public int width = 0;
    public int height = 0;
    public float spacing = .15f;
    // Start is called before the first frame update
    void Start()
    {
        CreateSinusoid(width, height);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateSinusoid(int width, int height)
    {
        Vector3 location = new Vector3(0, 0, 0);
        for(location.y = 0; location.y < height; location.y += spacing)
        {
            float rndFactor = Random.Range(0.5f, 1.5f);
            for (location.x = 0; location.x < width; location.x += spacing)
            {
                Vector3 spawnLocation = new Vector3(location.x, location.y + rndFactor * Mathf.Sin(rndFactor * location.x));
                GameObject.Instantiate(square, spawnLocation, Quaternion.identity);
            }
        }

    }
}
