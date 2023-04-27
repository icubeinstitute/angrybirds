using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int sceneTotalCount;
    int activeScene;

    void Start()
    {
        sceneTotalCount = SceneManager.sceneCountInBuildSettings;
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void OnLevelFinish()
    {
        if(activeScene < sceneTotalCount - 1)
        {
            SceneManager.LoadScene(activeScene += 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(activeScene);
    }
}
