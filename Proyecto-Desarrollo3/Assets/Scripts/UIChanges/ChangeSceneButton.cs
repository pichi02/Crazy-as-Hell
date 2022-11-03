using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private GameObject chargeScene;

    public void ChargeScene()
    {
        chargeScene.SetActive(true);
    }
    public void ChangeScene(string name)
    {
        SceneLoader.sceneLoader.LoadScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
