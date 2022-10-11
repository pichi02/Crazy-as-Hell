using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader sceneLoader;

    [SerializeField] private GameObject canvasLoader;
    private Image progressBar;
    private void Awake()
    {
        if (sceneLoader == null)
        {
            sceneLoader = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        canvasLoader.SetActive(true);

        do
        {
            await System.Threading.Tasks.Task.Delay(100);
            progressBar.fillAmount = scene.progress;

        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        canvasLoader.SetActive(false);
    }
}
