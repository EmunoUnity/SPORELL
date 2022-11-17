using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject acorn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(acorn);
    }
}
