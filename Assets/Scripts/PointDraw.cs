using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDraw : MonoBehaviour
{    public Test envoControl;

   
public GameObject prefabs;
int node;
    void Start()
    {   
        for (var i = 0; i < envoControl.spriteShape.spline.GetPointCount(); i++)
        {
            prefabs=Instantiate(prefabs,prefabs.transform.position,transform.rotation);
          
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
