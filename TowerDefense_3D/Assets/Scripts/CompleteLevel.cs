using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    public string menuSceneName = "MainMenu";
    public string nextLevel = "Level02";
    public SceneFader sceneFader;

    public void Continue()
    {
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
