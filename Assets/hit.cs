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

    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log(hit.name);
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

        Destroy(gameObject);
    }
}
