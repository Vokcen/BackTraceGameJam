using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{  
    public GameObject objectprefab;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Instantiate(objectprefab,-transform.up,transform.rotation);
        }
    }
}
