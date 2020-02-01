using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DestructableBlock : MonoBehaviour
{
    Collider2D m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;
    public float spacing = .15f;
    public GameObject square;

    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider2D>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        //Output this data into the console
        OutputData();

        CreateGrid(m_Min.x, m_Max.x, m_Min.y, m_Max.y);
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }

    void DestroyChildren(Transform root)
    {
        int childCount = root.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject.DestroyImmediate(root.GetChild(0).gameObject);
        }
    }

    void CreateGrid(float minX, float maxX, float minY, float maxY)
    {
        DestroyChildren(this.transform);
        Vector3 location = new Vector3(0, 0, 0);
        for (location.y = minY; location.y < maxY; location.y += spacing)
        {
            for (location.x = minX; location.x < maxX; location.x += spacing)
            {
                GameObject newObj = GameObject.Instantiate(square, location, Quaternion.identity);
                newObj.transform.parent = this.transform;
            }
        }
    }

}
