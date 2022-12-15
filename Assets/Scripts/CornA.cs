using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CornA : MonoBehaviour
{
    // Start is called before the first frame update
    public int nuts;
    private bool wait;
    
    void Start()
    {
        nuts = 15;
        wait = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && wait)
        {
            nuts = 15;
            //HealthBar.SetHealthBarValue(weird);
            PLAYER.life = 1;
            StartCoroutine(delaymore());
        }
    }

    IEnumerator delaymore()
    {
        wait = false;
        yield return new WaitForSeconds(30);
        wait = true;
    }


}
