using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private int _currentScene;
    public void loadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            _currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_currentScene + 1);
        }
        
    }


}
