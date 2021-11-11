using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public int ammo = 30;

    private int maxAmmo = 30;
    public Transform firePoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Invoke("Reload", 2.0f); 
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
            ammo--;
        }
    }

    void Shoot() 
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void Reload()
    {
        ammo = maxAmmo;
    }
}
