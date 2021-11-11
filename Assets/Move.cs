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
    [SerializeField] public ZombieUi zombieui;
    SpriteRenderer sprite;

    public int hits;
    private Health barricadeToHit;
    private float cooldownTime = Mathf.Infinity;
    public Animator anim;

    private void Awake()
    {
        zombieui = FindObjectOfType<ZombieUi>();
        float scaleVar = 4f + (GetModifier());
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(GetModifier(), GetModifier(), GetModifier(), 1);
        this.transform.localScale = new Vector3(scaleVar, scaleVar, 4f + GetModifier());
        barricadeToHit = GetComponentInParent<Health>();
        anim = GetComponent<Animator>();
        hits = (int)Random.Range(3f, 7f);
        moveSpeed = (int)Random.Range(2f, 6f);
        anim.SetBool("Run",true);
    }

    // Update is called once per frame
    void Update()
    {

        cooldownTime += Time.deltaTime;

        if (!NearBarricade() && hits > 0) 
        {
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * moveSpeed, enemy.position.y, enemy.position.z);

        }
        else 
        {
            anim.SetBool("Run", false);

            if (cooldownTime >= attackCooldown && hits > 0)
            {
                cooldownTime = 0;
                anim.SetTrigger("Attack");
                barricadeToHit.BreakBarricade(damage);
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

    public void beHurt(int damage)
    {
        hits -= damage;

        if (hits <= 0)
        {
            GetComponentInChildren<Head>().circle.enabled = false;
            boxColider.enabled = false;
            anim.SetTrigger("Die");
            zombieui.RegularKill();
            Invoke("DestroySelf", 2.0f);
        }

    }


    private void DestroySelf() 
    {
        anim.gameObject.GetComponent<Animator>().enabled = false;
        Destroy(gameObject);
    }

    float GetModifier()
    {
        float modifier = Random.Range(0f, 1f);
        if (Random.Range(0, 1) > 0)
            return -modifier;
        else
            return modifier;
    }
}
