using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        GameIsOver = false;
    }

	// Update is called once per frame
	void Update () {

        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        	
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }
    public void WinLevel()
    {
        Debug.Log("LEVEL WON!");
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

}
