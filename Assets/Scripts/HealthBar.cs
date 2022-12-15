using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private static Image HealthBarImage;
    

    void Start()
    {
        HealthBarImage = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetHealthBarValue(float value)
    {

        HealthBarImage.fillAmount = value;

        if (value <= 0)
        {
            Animator kell = GameObject.Find("Squirell").GetComponent<Animator>();
            kell.SetBool("death", true);

        }
        /*if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }*/
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    public static void SetHealthBarColor(Color healthColor)
    {
        //HealthBarImage.color = healthColor;
    }
}
