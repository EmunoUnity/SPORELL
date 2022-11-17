using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour
{
    public float normaldamage = 100;
    public EnemyNav enemyNav;

    private Animation help;
    

    public bool comboOne;

    // Start is called before the first frame update
    void Start()
    {
        //enemyNav = GetComponent<EnemyNav>();

        comboOne = false;

        help = gameObject.GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //help.Play("SwingOne");

        if(Input.GetKeyDown(KeyCode.Mouse0) && !comboOne)
        {
            help.Play("SwingOne");
            comboOne = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
