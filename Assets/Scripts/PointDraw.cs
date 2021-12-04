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
            prefabs=Instantiate(prefabs,envoControl.spriteShape.transform.InverseTransformPoint(envoControl.spriteShape.spline.GetPosition(i)),transform.rotation);
          
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
