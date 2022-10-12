using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader sceneLoader;

    [SerializeField] private GameObject loaderCanvas;

    [SerializeField] private TextMeshProUGUI textProgress;
    [SerializeField] private Image progressBar;

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

    public IEnumerator Load()
    {
        yield return null;

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Gameplay");

        loadOperation.allowSceneActivation = false;

        loaderCanvas.SetActive(true);

        while (!loadOperation.isDone)
        {
            float progressF = Mathf.Clamp01(loadOperation.progress / .09f);

            progressBar.fillAmount = progressF;

            textProgress.text = "" + progressF * 100 + "%";

            if (loadOperation.progress >= 0.9f)
            {
                textProgress.text = "Press space bar to continue";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    loadOperation.allowSceneActivation = true;
                    loaderCanvas.SetActive(false);
                }
            }

            yield return null;
        }
    }

    //public async void LoadScene(string sceneName)
    //{
    //    var scene = SceneManager.LoadSceneAsync(sceneName);
    //    scene.allowSceneActivation = false;

    //    loaderCanvas.SetActive(true);

    //    do
    //    {
    //        await System.Threading.Tasks.Task.Delay(100);
    //        progressBar.fillAmount = scene.progress;

    //    } while (scene.progress < 0.9f);

    //    scene.allowSceneActivation = true;
    //    loaderCanvas.SetActive(false);
    //}
}
