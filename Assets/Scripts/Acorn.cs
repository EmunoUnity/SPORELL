using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject acorn;
    public Transform Trans;
    private GameObject Killcorn;
    void Start()
    {
        transform.position = Trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enviroment" || collision.gameObject.tag == "Enemy")
        {
            
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;
            Killcorn = Instantiate(acorn, transform.position, transform.rotation) as GameObject;

            //transform.position = Trans.position;
            StartCoroutine(thenDie());

        }
    }
    IEnumerator thenDie()
    {
        yield return new WaitForSeconds(3);
        transform.position = Trans.position;
        yield return new WaitForSeconds(5f);
        Destroy(Killcorn);
    }
}
