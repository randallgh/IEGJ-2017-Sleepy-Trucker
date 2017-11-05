using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitOnClick : MonoBehaviour
{

    public Button quitButton;
    // Use this for initialization
    void Start()
    {
        Button btn = quitButton.GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void QuitGame()
    {
        Application.Quit();
    }
}
