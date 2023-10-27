using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas, highscoreCanvas, creditCanvas;
    [SerializeField] private Text shipsDestroyedHighscore, meteorsDestroyedHighscore, waveHighscore;

    public void StartGame()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void OpenCloseHighscoreCanvas(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highscoreCanvas.enabled = open;
        creditCanvas.enabled = !open;

        if (open)
        {
            DisplayHighscore();
        }
    }

    void DisplayHighscore()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
