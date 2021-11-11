using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieUi : MonoBehaviour
{
    [SerializeField] private Fire weapon;
    [SerializeField] private Health barricade;
    [SerializeField] public UnityEngine.UI.Text ammoText;
    [SerializeField] public UnityEngine.UI.Text reloadText;


    public Gameover gameover;
    private int ammoToDisplay;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        ammoToDisplay = weapon.GetComponent<Fire>().ammo;
        ammoText.text = ammoToDisplay.ToString();

        if(ammoToDisplay < 5) 
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

    private void ammoLow()
    {
        reloadText.text = "RELOAD [R]";
        ammoText.color = Color.red;
        reloadText.color = Color.red;
    }

}
