using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    public void LoadGameOver()
    {
        SceneManager.LoadScene(0);
    }

}
