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

    [SerializeField] private GameObject panel;

    [SerializeField] private TextMeshProUGUI textProgress;
    [SerializeField] private Image progressBar;

    private void Awake()
    {
        Time.timeScale = 1f;
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

    public IEnumerator Load(string name)
    {

        textProgress = GetComponent<TextMeshProUGUI>();
        yield return null;

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(name);

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

    public void LoadScene(string scene)
    {

        SceneManager.LoadScene(scene);

    }

    public void Quit()
    {
        Application.Quit();
    }

}
