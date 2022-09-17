using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Waves;
    public int startWaves;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Waves = startWaves;
        //TODO Faire les waves avec le tuto https://www.youtube.com/watch?v=n2DXF1ifUbU&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=3
    }
}
