using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{

    private Move owner;
    private int ownerHealth;
    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.GetComponent<Move>();
        ownerHealth = owner.hits;
    }

    public void Headshot()
    {
        Move monster = owner;

        if (monster != null)
        {
            monster.beHurt(ownerHealth);
        }
    }
}
