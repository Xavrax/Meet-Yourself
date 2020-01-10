using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        exitButton.GetComponent<Button>().onClick.AddListener(Exit);
        startButton.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    static void StartGame()
    {
        SceneManager.LoadScene("PlayerTestingScene", LoadSceneMode.Single);
    }
    
    static void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
