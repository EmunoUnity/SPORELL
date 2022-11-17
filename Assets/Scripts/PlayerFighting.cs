using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour
{
    public float normaldamage = 100;
    public EnemyNav enemyNav;

    private Animation help;
    

    public bool comboOne;
    public bool comboTwo;

    // Start is called before the first frame update
    void Start()
    {
        //enemyNav = GetComponent<EnemyNav>();

        comboOne = false;
        comboTwo = false;

        help = gameObject.GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //help.Play("SwingOne");

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!comboOne && !comboTwo)
            {
                help.Play("SwingOne");
                comboOne = true;
                StartCoroutine(comboOnePause());
            }
            else if (comboOne && !comboTwo)
            {
                help.Play("SwingTwo");
                comboTwo = true;
                StartCoroutine(comboTwoPause());
                
            }
            else if (comboTwo && comboOne)
            {
                help.Play("SwingThree");
                comboOne = false;
                comboTwo = false;
            }
        }
        
    }

    public IEnumerator comboOnePause()
    {
        yield return new WaitForSeconds(1);
        comboOne = false;
    }

    public IEnumerator comboTwoPause()
    {
        yield return new WaitForSeconds(2);
        comboTwo = false;
    }
}
