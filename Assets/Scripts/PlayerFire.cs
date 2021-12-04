using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerFire : MonoBehaviour
{
    public SpriteShapeController shapeController;
    public SpriteShapeGenerator spriteShapeGenerator;
   public int value;
    public int index;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {   
       if(Input.GetKey(KeyCode.Q))
        {
            shapeController.spline.GetPosition(index);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            shapeController.spline.SetPosition(index,transform.forward*5);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {  
    
        
       
    }
}
