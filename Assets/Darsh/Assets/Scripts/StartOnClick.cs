    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartOnClick : MonoBehaviour {

    public Button startButton; 
	// Use this for initialization
	void Start () {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
	}

    // Update is called once per frame
    void StartGame()
    {
        Application.LoadLevel(1);
    }
}
