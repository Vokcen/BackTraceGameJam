using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.InputSystem;
using DG.Tweening;
using System.Collections;



public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private float moveInput;


    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    public LayerMask whatIsGround;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
             moveInput=Input.GetAxis("Horizontal");
             rb.velocity=new Vector2(moveInput*speed,rb.velocity.y);
    }

    void Update()
    {
          isGrounded=Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround);
        if (isGrounded==true&&Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity=Vector2.up*jumpForce;
        }
    }


}
