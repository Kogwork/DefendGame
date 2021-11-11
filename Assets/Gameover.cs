using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    public void Setup() 
    {
        Invoke("endScreen", 1.2f); 
    }

    public void TryAgain() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void endScreen() 
    {
        gameObject.SetActive(true);
    }
}
