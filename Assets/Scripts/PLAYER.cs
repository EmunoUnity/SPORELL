using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    // Start is called before the first frame update
    public static float life = 1f;
    public float testlife;

    void Start()
    {
        testlife = life;
        HealthBar.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.SetHealthBarValue(life);
    }
}
