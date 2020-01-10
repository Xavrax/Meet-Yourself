using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            if (_won)
            {
                SceneManager.LoadScene("YouWonScene", LoadSceneMode.Additive);
                _won = true;
            }
        }
    }

    private bool _won = false;

}
