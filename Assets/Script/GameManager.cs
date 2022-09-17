using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text moneyText;
    public TMP_Text wavesText;

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " Vie";
        moneyText.text = PlayerStats.Money.ToString() + " $";
        wavesText.text = "Waves " + PlayerStats.Waves.ToString();
    }
}
