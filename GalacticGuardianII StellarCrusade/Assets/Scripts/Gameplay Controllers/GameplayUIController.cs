using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController instance;

    [SerializeField] private Text waveInfoText, shipsDestroyedInfoText, meteorsDestroyedInfoText;
    [SerializeField] private int waveCount, shipsDestroyedCount, meteorsDestroyedCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetWaveCount()
    {
        waveCount++;
        waveInfoText.text = "WAVE - " + waveCount;
    }

    public void SetShipsDestroyed()
    {
        shipsDestroyedCount++;
        shipsDestroyedInfoText.text = shipsDestroyedCount + "X ";
    }

    public void SetMeteorsDestroyed()
    {
        meteorsDestroyedCount++;
        meteorsDestroyedInfoText.text = meteorsDestroyedCount + "X ";
    }

    public int GetShipDestroyedCount()
    {
        return shipsDestroyedCount;
    }

    public int GetMeteorsDestroyedCount()
    {
        return meteorsDestroyedCount;
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    public void SetInfoUI(int infoType)
    {
        switch (infoType)
        {
            case 1:
                waveCount++;
                waveInfoText.text = "WAVE - " + waveCount;
                break;

            case 2:
                shipsDestroyedCount++;
                shipsDestroyedInfoText.text = shipsDestroyedCount + "X ";
                break;

            case 3:
                meteorsDestroyedCount++;
                meteorsDestroyedInfoText.text = meteorsDestroyedCount + "X ";
                break;
        }
    }
}