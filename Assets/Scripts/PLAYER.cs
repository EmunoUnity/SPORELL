using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYER : MonoBehaviour
{
    // Start is called before the first frame update
    public static float life = 1f;
    public float testlife;

    void Start()
    {
        testlife = life;
        HealthBar.SetHealthBarValue(1);
        GetComponent<PlayerFighting>().enabled = true;
        GetComponent<CharacterMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.SetHealthBarValue(life);

        if(HealthBar.GetHealthBarValue() <= 0)
        {
            Debug.Log("Game Over!!!");
            StartCoroutine(deathdelay());
            GetComponent<PlayerFighting>().enabled = false;
            GetComponent<CharacterMovement>().enabled = false;
        }
    }

    IEnumerator deathdelay()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
    }
}
