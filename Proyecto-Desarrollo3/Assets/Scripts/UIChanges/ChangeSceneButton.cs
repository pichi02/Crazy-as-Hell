using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public void ChangeSceneWithLoadingBar(string name)
    {
        StartCoroutine(SceneLoader.sceneLoader.Load(name));
    }
    public void ChangeScene(string name)
    {
        SceneLoader.sceneLoader.LoadScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
