using UnityEngine;
using TMPro;
using System.Collections;

public class UIGameplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textVersion;

    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private CanvasGroup panelWin;

    [SerializeField] private CarLife carLife;
    [SerializeField] private SpeedWay speedWay;

    void Start()
    {
        textVersion.text = Application.version;
        carLife.OnDead += ActiveLosePanel;
        speedWay.OnWin += ActiveWinPanel;
    }

    private void ActiveLosePanel()
    {
        StartCoroutine(CoroutineActivePanel(panelLose));
    }

    private void ActiveWinPanel()
    {
        StartCoroutine(CoroutineActivePanel(panelWin));
    }

    private IEnumerator CoroutineActivePanel(CanvasGroup panel)
    {
        ActivePanel(panel ,false);

        float timer = 0;
        float maxTime = 2;

        while (timer < maxTime)
        {
            timer += Time.deltaTime;
            panel.alpha = timer / maxTime;
            yield return null;
        }

        ActivePanel(panel, true);
    }

    private void ActivePanel(CanvasGroup panel, bool isActive)
    {
        panel.alpha = isActive ? 1 : 0;
        panel.interactable = isActive;
        panel.blocksRaycasts = isActive;
    }
}
