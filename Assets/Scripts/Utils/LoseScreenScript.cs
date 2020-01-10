using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreenScript : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        backButton.GetComponent<Button>().onClick.AddListener(BackToMenu);
    }

    static void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
