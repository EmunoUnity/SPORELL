using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CornA : MonoBehaviour
{
    // Start is called before the first frame update
    public static int nuts;
    void Start()
    {
        nuts = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            nuts = 15;
        }
    }


}
