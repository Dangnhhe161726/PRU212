using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{

    public string sceneName;

    public void UpdateScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
