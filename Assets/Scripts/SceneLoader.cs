using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    //cached reference
    GameStatus gamestatus;

    private void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            LoadGameOver();
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void LoadStartScene()
    {
        gamestatus.ResetGame();
        SceneManager.LoadScene("Start Menu");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
