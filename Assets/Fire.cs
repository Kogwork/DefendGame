using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public int ammo = 30;

    private int maxAmmo = 30;
    public Transform firePoint;
    public GameObject bullet;
    private Animator anim;
    private bool reloading = false;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            reloading = true;
            Invoke("Reload", 2.0f); 
        }

        if (Input.GetButtonDown("Fire1") && ammo > 0 && !reloading) 
        {
            Shoot();
            ammo--;
        }
    }

    void Shoot() 
    {
        anim.SetTrigger("Fire");
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void Reload()
    {
        ammo = maxAmmo;
        reloading = false;
    }
}
