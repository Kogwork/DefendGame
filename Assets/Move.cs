using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float range;
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private LayerMask barricade;
    [SerializeField] private Transform enemy;
    private float cooldownTime = Mathf.Infinity;
    private Animator anim;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        cooldownTime += Time.deltaTime;

        if (!NearBarricade()) 
        {
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * moveSpeed, enemy.position.y, enemy.position.z);

        }
        else 
        {
            if (cooldownTime >= attackCooldown)
            {
                cooldownTime = 0;
                anim.SetTrigger("Attack");
                barricadehp.BreakBarricade(damage);
            }
        }
    }

    private bool NearBarricade() 
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColider.bounds.center + transform.right * range, boxColider.bounds.size, 0, Vector2.left, 0, barricade);

        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColider.bounds.center + transform.right * range, boxColider.bounds.size);
    }
}
