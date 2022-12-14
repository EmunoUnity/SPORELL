using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private int wave;
    public int indeed;
    private int done;
    public int fuck;
    public static int outdeed;
    
    public GameObject enemy;
    private GameObject eme;
    void Start()
    {
        wave = 1;
        indeed = 0;
        fuck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        done = indeed / 3;
        if (Input.GetKeyUp(KeyCode.Backspace) && indeed == 0)
        {
            indeed = 3;
        }

        if (outdeed == indeed)
        {
            indeed *= 3;
            wave++;
        }

        if(fuck < done)
        {
            eme = Instantiate(enemy, transform.position, transform.rotation) as GameObject;
            fuck++;
        }
        
    }
}
