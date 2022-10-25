using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text moneyText;
    public TMP_Text wavesText;

    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject upgradeUI;

    private void Start()
    {
        gameIsOver = false;
    }
    void Update()
    {
        //Quit game
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        livesText.text = PlayerStats.Lives.ToString() + " Vie";
        moneyText.text = PlayerStats.Money.ToString() + " $";
        wavesText.text = "Waves " + PlayerStats.Rounds.ToString() +"/6";

        if (gameIsOver)
            return;
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void UpgradeMenu()
    {
        if (upgradeUI.activeSelf == false)
        {
            upgradeUI.SetActive(true);
            PauseGame();
        }
        else if (upgradeUI.activeSelf == true)
        {
            upgradeUI.SetActive(false);
            ResumeGame();
        }
    }

    public void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
        PauseGame();
    }

}
