using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float timer;

    public float sleepyness; //From 1 - 100
    public float sleepyModifier;

    public GameObject truck;
    public GameObject panel;
    private Image panelImage;

    public GameObject time;
    private Text timeText;

	// Use this for initialization
	void Start () {
        panelImage = panel.GetComponent<Image>();
        timeText = time.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        Sleepy();
	}

    void Sleepy()
    {

        sleepyness += sleepyModifier * Time.deltaTime;
        sleepyness = Mathf.Clamp(sleepyness, 0, 100);

        //timer += Time.deltaTime;
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;

        Color darkness = panelImage.color;
        darkness.a = sleepyness;
        panelImage.color = darkness;
    }
}
