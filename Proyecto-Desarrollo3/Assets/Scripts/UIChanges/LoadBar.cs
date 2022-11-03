using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textProgress;
    [SerializeField] private Image progressBar;

    void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return null;

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Gameplay");

        loadOperation.allowSceneActivation = false;

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
                }
            }

            yield return null;
        }
    }
}
