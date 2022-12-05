using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enviroment")
        {
            Debug.Log("collided");
            acorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            acorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            acorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            acorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;

            StartCoroutine(thenDie());
        }

        if(collision.gameObject.tag == "Enemy")
        {

        }

        IEnumerator thenDie()
        {
            yield return new WaitForSeconds(4f);
            Destroy(acorn);
        }
    }
}
