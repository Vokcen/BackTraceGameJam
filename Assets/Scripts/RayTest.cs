using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
public class RayTest : MonoBehaviour
{
    // Float a rigidbody object a set distance above a surface.

    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;         // Force reduction proportional to speed (reduces bouncing).

    Rigidbody2D rb2D;
    public Test envoirementControl;
    public Transform gizmo;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {   var mouse= Mouse.current;
         Vector3 screenPos = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
           Vector3 screenVector2=new Vector3(screenPos.x,screenPos.y,0);
         if (Input.GetMouseButton(1))
         {
             transform.position=screenVector2;
               envoirementControl.AddPoint(transform.position);
         }
         if (Input.GetMouseButton(0))
         {
              gizmo.transform.position=screenVector2;
            envoirementControl.GizmoView(gizmo.transform.position);
         }
         
         
    
    }
    //void FixedUpdate()
    //{
        // Cast a ray straight down.
      //  RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position);

        // If it hits something...
        //if (hit.collider != null)
       // { 
         //   envoirementControl.AddPoint(transform.position);

       // }

   // }
    Sequence WandAnimation()
    {


        Sequence s = DOTween.Sequence();


        return s;
    }
}
