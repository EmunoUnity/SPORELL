using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PowerUp : MonoBehaviour
    
{
    private GameObject[] pain;
    public ExperienceBar exp;

    private int minRange;
    // Start is called before the first frame update
    void Start()
    {
        exp = FindObjectOfType<ExperienceBar>();
        minRange = 70;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ExperienceBar.bars <= 0.2f)
        {
            pain = GameObject.FindGameObjectsWithTag("Enemy");

            foreach(GameObject go in pain)
{
                float distance = Vector3.Distance(transform.position, go.transform.position);

                if(distance < minRange)
                {
                    go.GetComponent<EnemyNav>().enemyLife -= 200;
                    
                }
            }

            ExperienceBar.bars = 0f;
        }
    }
}
