using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
Move();
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        transform.position += new Vector3(x, 0, 0) * Time.deltaTime * speed;
    }
}
