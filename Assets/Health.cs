using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int hitpoint = 100;
    [SerializeField] public Sprite stage4;
    [SerializeField] public Sprite stage3;
    [SerializeField] public Sprite stage2;
    [SerializeField] public Sprite stage1;

    public SpriteRenderer spriteRenderer;
    private int maxHealth = 100;
    private int precnetHealth = 100;
    // Update is called once per frame
    void Update()
    {
        if (hitpoint <= 0)
        {
            Destroy(gameObject);
            UnityEditor.EditorApplication.isPlaying = false;
        }

        precnetHealth = maxHealth * hitpoint / 100;

        switch (precnetHealth) 
        {
            case int n when n >= 80:
                spriteRenderer.sprite = stage4;
                break;
            case int n when n >= 60:
                spriteRenderer.sprite = stage3;
                break;
            case int n when n >= 40:
                spriteRenderer.sprite = stage2;
                break;
            case int n when n >= 20:
                spriteRenderer.sprite = stage1;
                break;

        }
    }

    public void BreakBarricade(int damage)
    {
        hitpoint -= damage;
    }
}