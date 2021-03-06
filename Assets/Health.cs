using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] public int hitpoint = 100;
    [SerializeField] public Sprite stage4;
    [SerializeField] public Sprite stage3;
    [SerializeField] public Sprite stage2;
    [SerializeField] public Sprite stage1;
    [SerializeField] private BoxCollider2D boxColider;

    public SpriteRenderer spriteRenderer;
    public bool endgame = false;
    private int maxHealth = 100;
    private int precnetHealth = 100;
    // Update is called once per frame
    void Update()
    {
        if (hitpoint <= 0)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
            endGame();
        }

        precnetHealth = maxHealth * hitpoint / 100;

        switch (precnetHealth) 
        {
            case int n when n >= 80:
                break;
            case int n when n >= 60:
                spriteRenderer.sprite = stage4;
                break;
            case int n when n >= 40:
                spriteRenderer.sprite = stage3;
                break;
            case int n when n >= 20:
                spriteRenderer.sprite = stage2;
                break;
            case int n when n >= 0:
                spriteRenderer.sprite = stage1;
                break;

        }
    }

    private void endGame() 
    {
        boxColider.enabled = false;
        endgame = true;
    }

    public void BreakBarricade(int damage)
    {
        hitpoint -= damage;
    }
}