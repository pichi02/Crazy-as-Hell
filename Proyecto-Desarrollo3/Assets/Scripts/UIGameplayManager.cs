
using UnityEngine;
using TMPro;

public class UIGameplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textVersion;
    void Start()
    {
        textVersion.text = Application.version;
    }
}
