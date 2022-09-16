using UnityEngine;

public class Laps : MonoBehaviour
{
    [SerializeField] private int lapsToWin;

    public void LapsToWin(int maxLaps)
    {
        if (maxLaps >= lapsToWin)
        {
            Debug.Log("Gano");
        }
    }
}
