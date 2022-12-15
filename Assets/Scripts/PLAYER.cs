using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYER : MonoBehaviour
{
    // Start is called before the first frame update
    public static float life = 1f;
    public float testlife;
    public bool stopbeingstupid;

    

    void Start()
    {
        stopbeingstupid = false;
        testlife = life;
        HealthBar.SetHealthBarValue(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.SetHealthBarValue(life);
        
        if (HealthBar.GetHealthBarValue() <= 0 && !stopbeingstupid)
        {
            Debug.Log("Game Over!!!");
            
            PlayerFighting.squir = false;
            StartCoroutine(deathdelay());
        }
        
    }

    IEnumerator deathdelay()
    {
        yield return new WaitForSeconds(4);
        if (!stopbeingstupid)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
            stopbeingstupid = true;
        }
        
    }
}
