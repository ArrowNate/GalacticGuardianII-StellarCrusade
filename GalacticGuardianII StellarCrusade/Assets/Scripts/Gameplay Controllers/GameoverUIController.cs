using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUIController : MonoBehaviour
{
    public static GameoverUIController instance;

    [SerializeField] private Canvas playerInfoCanvas, shipsAndMeteorInfoCanvas, gameOverCanvas;
    [SerializeField] private Text shipsDestroyedFinalInfoText, meteorsDestroyedFinalInfoText, waveFinalInfoText;
    [SerializeField] private Text shipsDestroyedHighscoreText, meteorsDestroyedHighscoreText, waveHighscoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        gameOverCanvas.enabled = false;
    }

    public void GameoverPanel()
    {
        playerInfoCanvas.enabled = false;
        shipsAndMeteorInfoCanvas.enabled = false;
        //playerInfoCanvas.enabled = shipsAndMeteorInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        int shipsDestroyedFinal = GameplayUIController.instance.GetShipDestroyedCount();
        int meteorsDestroyedFinal = GameplayUIController.instance.GetMeteorsDestroyedCount();
        int waveCountFinal = GameplayUIController.instance.GetWaveCount();

        waveCountFinal--;

        shipsDestroyedFinalInfoText.text = "X " + shipsDestroyedFinal;
        meteorsDestroyedFinalInfoText.text = "X " + meteorsDestroyedFinal;
        waveFinalInfoText.text = "WAVE - " + waveCountFinal;

        CalculateHighscore(shipsDestroyedFinal, meteorsDestroyedFinal, waveCountFinal);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
    }

    void CalculateHighscore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCurrent)
    {
        int shipsDestroyedHighscore = DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        int meteorsDestroyedHighscore = DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        int waveHighscore = DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

        if (shipsDestroyedCurrent > shipsDestroyedHighscore)
            DataManager.SaveData(TagManager.SHIPS_DESTROYED_DATA, shipsDestroyedCurrent);

        if (meteorsDestroyedCurrent > meteorsDestroyedHighscore)
            DataManager.SaveData(TagManager.METEORS_DESTROYED_DATA , meteorsDestroyedCurrent);

        if (waveCurrent > waveHighscore)
            DataManager.SaveData(TagManager.WAVE_NUMBER_DATA, waveCurrent);

        shipsDestroyedHighscoreText.text = "X " + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorsDestroyedHighscoreText.text = "X " + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        waveHighscoreText.text = "WAVE - " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
    }
}