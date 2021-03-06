using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{

    public float speed = 22f;
    public Rigidbody2D body;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;
        anim = GetComponent<Animator>();
        Invoke("DestroyBullet", 4f);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        Move monster = hit.GetComponent<Move>();
        Head isHeadshot = hit.GetComponent<Head>();

        if (isHeadshot != null) 
        {
            isHeadshot.Headshot();
        }
        else if (monster != null) 
        {
            monster.beHurt(1);
        }

        DestroyBullet();
    }

    void DestroyBullet() 
    {
        Destroy(gameObject);
    }
}
