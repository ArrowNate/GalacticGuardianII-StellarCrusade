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
        shipsDestroyedHighscore.text = "X " + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorsDestroyedHighscore.text = "X " + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        waveHighscore.text = "- " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
    }

    public void Quit()
    {
        Application.Quit();
    }
}