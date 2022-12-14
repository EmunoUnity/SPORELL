using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExperienceBar : MonoBehaviour
{
    // Start is called before the first frame update
    public static float bars;
    private static Image EXPBarImage;
    
    void Start()
    {
        bars = 0;
        EXPBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScreen");
        }
    }

    public static void SetEXPBarValue(float value)
    {
        EXPBarImage.fillAmount = value;
        bars = value;
    }

    public static float GetEXPBarValue()
    {
        return EXPBarImage.fillAmount;
    }
}
