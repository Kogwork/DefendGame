using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int speed = 5;
    [SerializeField] public Rigidbody2D body;
    public Animator anim;

    // Update is called once per frame

    Vector2 movement;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0f) 
        {
            anim.SetBool("walk",true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }
}
