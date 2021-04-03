using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed =1;
    Animator animator;
    Rigidbody2D rigidbody2d;
    float scaleX;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity= new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed;
        rigidbody2d.velocity=velocity;
        animator.SetFloat("Speed", velocity.sqrMagnitude);
    //Flip Animation
    if(velocity.x != 0)
    {
        Vector3 scale= transform.localScale;
        scale.x = scaleX* (velocity.x >= 0 ? 1 : -1);
        transform.localScale = scale;
        }
    }
}
