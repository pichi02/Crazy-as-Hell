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
    [SerializeField] private PowerUp powerUp;

    [SerializeField] private TextMeshProUGUI powerUpTypeText;
    [SerializeField] private TextMeshProUGUI lapsText;

    [SerializeField] private TrackCheckpoint trackCheckpoint;

    [SerializeField] private TextMeshProUGUI raceTimeText;

    [SerializeField] private RaceTime raceTime;

    private CanvasGroup powerUpTypeCanvasGroup;
    private CanvasGroup trackTextCanvasGroup;

    private IEnumerator activePanelPowerUp;
    void Start()
    {
        trackTextCanvasGroup = lapsText.GetComponent<CanvasGroup>();
        powerUpTypeCanvasGroup = powerUpTypeText.GetComponent<CanvasGroup>();
        textVersion.text = Application.version;
        carLife.OnDead += ActiveLosePanel;
        speedWay.OnWin += ActiveWinPanel;
        PowerUp.OnPowerUpPick += UpdatePowerUpType;
        powerUpTypeText.gameObject.SetActive(false);
        lapsText.gameObject.SetActive(false);
        trackCheckpoint.OnLapFinish += ShowTrackText;
        raceTime.OnTimeChange += ChangeRaceTimeText;
        raceTime.OnTimeFinish += ActiveLosePanel;
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
        ActivePanel(panel, false);

        float timer = 0;
        float maxTime = 2;

        while (timer < maxTime)
        {
            timer += Time.deltaTime;
            panel.alpha = timer / maxTime;
            yield return null;
        }
        if (panel.transform.CompareTag("PowerUpText"))
        {
            panel.gameObject.SetActive(false);
        }
        if (panel.transform.CompareTag("LapsText"))
        {
            panel.gameObject.SetActive(false);
        }
        ActivePanel(panel, true);
    }

    private void ActivePanel(CanvasGroup panel, bool isActive)
    {
        panel.alpha = isActive ? 1 : 0;
        panel.interactable = isActive;
        panel.blocksRaycasts = isActive;
    }

    private void UpdatePowerUpType(TYPE type)
    {
        powerUpTypeText.gameObject.SetActive(true);
        powerUpTypeText.text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(type.ToString().Replace('_', ' ').ToLower());

        if (activePanelPowerUp != null)
        {
            StopCoroutine(activePanelPowerUp);
        }
        activePanelPowerUp = CoroutineActivePanel(powerUpTypeCanvasGroup);
        StartCoroutine(activePanelPowerUp);
    }
    private void UpdateLapsText()
    {
        lapsText.text = "Vuelta: " + trackCheckpoint.index + " / " + speedWay.maxLaps;
    }
    private void ShowTrackText()
    {
        UpdateLapsText();
        lapsText.gameObject.SetActive(true);
        StartCoroutine(CoroutineActivePanel(trackTextCanvasGroup));
        Debug.Log("entro");

    }
    private void OnDestroy()
    {
        carLife.OnDead -= ActiveLosePanel;
        speedWay.OnWin -= ActiveWinPanel;
        PowerUp.OnPowerUpPick -= UpdatePowerUpType;
    }

    private void ChangeRaceTimeText(float time)
    {
        raceTimeText.text = time.ToString("0.00");
    }
}
