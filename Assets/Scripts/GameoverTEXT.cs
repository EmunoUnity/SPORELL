using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameoverTEXT : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI uGUI;
    private int wavy;
    private int death;
    void Start()
    {
        wavy = GameObject.Find("EnemySpawner").GetComponent<Spawner>().wave;
        death = Spawner.outdeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Text myText = GameObject.Find("Waves").GetComponent<Text>();
        textMeshProUGUI.text = "Waves: " + wavy;
        uGUI.text = "You have defeated " + death;
    }
}
