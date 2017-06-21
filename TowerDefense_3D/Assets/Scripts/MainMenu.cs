using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "LevelSelectMenu";
    public SceneFader sceneFader;

    public void Play()
    {
        Debug.Log("Loading " + levelToLoad);
        // FindObjectOfType<SceneFader>().FadeTo(levelToLoad); // So muss SceneFader nicht referenziert werden
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }


}
