using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject acorn;
    public Transform Transform;
    private GameObject Killcorn;
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
            
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;

            transform.position = transform.position;
            StartCoroutine(thenDie());

        }

        if(collision.gameObject.tag == "Enemy")
        {

        }


    }
    IEnumerator thenDie()
    {
        yield return new WaitForSeconds(7f);
        Destroy(Killcorn);
    }
}
