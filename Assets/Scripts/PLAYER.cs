using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    // Start is called before the first frame update
    public static float life = 100;
    public float testlife;

    void Start()
    {
        testlife = life;
    }

    // Update is called once per frame
    void Update()
    {
        testlife = life;

    }
}
