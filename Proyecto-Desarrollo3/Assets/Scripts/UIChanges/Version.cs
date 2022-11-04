using UnityEngine;
using TMPro;

public class Version : MonoBehaviour
{
    [SerializeField] private TMP_Text textVersion;

    void Start()
    {
        textVersion.text = Application.version;
    }
}
