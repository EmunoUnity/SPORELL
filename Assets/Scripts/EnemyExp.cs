using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExp : MonoBehaviour
{
    // Start is called before the first frame update
    private static EnemyNav nav;
    public GameObject orbs;
    private GameObject exp;
    private bool gain;
    private bool stop;
    //public float deathrate;
    void Start()
    {
        nav = GetComponent<EnemyNav>();
        gain = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //deathrate = nav.enemyLife;

        if (nav.enemyLife <= 0 && !stop)
        {
            StartCoroutine(pausing());
        }

        if (gain)
        {
            exp = Instantiate(orbs, transform.position, transform.rotation) as GameObject;
        }
    }

    IEnumerator pausing()
    {
        yield return new WaitForSeconds(1.3f);
        gain = true;
        yield return new WaitForSeconds(1f);
        stop = true;
        gain = false;
    }
}
