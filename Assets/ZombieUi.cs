using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieUi : MonoBehaviour
{
    [SerializeField] private Fire weapon;
    [SerializeField] private Health barricade;
    [SerializeField] public UnityEngine.UI.Text ammoText;
    [SerializeField] public UnityEngine.UI.Text reloadText;
    [SerializeField] public UnityEngine.UI.Text headshot;
    [SerializeField] public UnityEngine.UI.Text kills;


    public Gameover gameover;
    private int headshotCount;
    private int ammoToDisplay;
    private int killsCount;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        ammoToDisplay = weapon.GetComponent<Fire>().ammo;
        ammoText.text = ammoToDisplay.ToString();
        headshot.text = headshotCount.ToString();
        kills.text = killsCount.ToString();

        if (ammoToDisplay < 5) 
        {
            ammoLow();

        }
        else
        {
            ammoText.color = Color.yellow;
            reloadText.text = string.Empty;
        }

        if(barricade.endgame)
        {
            gameover.Setup();
        }
    }
    public void HeadshotKill() 
    {
        headshotCount++;
    }

    public void RegularKill()
    {
        killsCount++;
    }

    private void ammoLow()
    {
        reloadText.text = "RELOAD [R]";
        ammoText.color = Color.red;
        reloadText.color = Color.red;
    }

}
