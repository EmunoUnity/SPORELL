using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int wave;
    public int indeed;
    private int done;
    public int fuck;
    public static int outdeed;

    public GameObject enemy;
    private GameObject eme;
    public GameObject boss;
    private GameObject bif;
    void Start()
    {
        outdeed = 10;
        wave = 1;
        indeed = 0;
        fuck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        done = indeed / 3;
        if (Input.GetKeyDown(KeyCode.Mouse0) && indeed == 0)
        {
            indeed = 3;
            outdeed = 0;
        }

        if (outdeed == indeed)
        {
            indeed *= 3;
            wave++;
        }

        if (fuck < done)
        {
            eme = Instantiate(enemy, transform.position, transform.rotation) as GameObject;

            fuck++;

            if (wave == 5 || wave == 10 || wave == 15 || wave == 20)
            {
                //spawn boss
                bif = Instantiate(boss, transform.position, transform.rotation) as GameObject;
                bif = Instantiate(boss, transform.position, transform.rotation) as GameObject;
            }
        }


    }
}

    
