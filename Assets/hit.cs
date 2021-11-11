using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;
    }
}
