using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exp : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private float speed = 3;
    public float experience = 0.02f;
    private float currentBar;
    //private ExperienceBar experienceBar;
    void Start()
    {
        player = GameObject.Find("Player");
        //experienceBar = FindObjectOfType<ExperienceBar>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            currentBar = ExperienceBar.bars + experience;
            //experienceBar.experience = experience;

            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.7f);
        ExperienceBar.SetEXPBarValue(currentBar);
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
}
