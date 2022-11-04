using UnityEngine;

public class SlideTutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialScreens;

    private int index = 0;

    private void Update()
    {
        for (int i = 0; i < tutorialScreens.Length; i++)
        {
            if (index == 0)
            {
                tutorialScreens[2].SetActive(false);
                tutorialScreens[0].SetActive(true);
                tutorialScreens[1].SetActive(false);
            }
            else if (index == 1)
            {
                tutorialScreens[0].SetActive(false);
                tutorialScreens[1].SetActive(true);
                tutorialScreens[2].SetActive(false);
            }
            else if (index == 2)
            {
                tutorialScreens[1].SetActive(false);
                tutorialScreens[2].SetActive(true);
                tutorialScreens[0].SetActive(false);
            }
            else if (index > 2)
            {
                index = 0;
            }
            else if (index == -1)
            {
                index = 2;
            }
        }
    }

    public void RightButton()
    {
        index++;
    }

    public void LeftButton()
    {
        index--;
    }
}
