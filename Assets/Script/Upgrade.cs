using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public GameObject wallPrefab;

    public TMP_Text currentFirePower;
    public TMP_Text btnTextFirePower;
    public TMP_Text currentBulletSpeed;
    public TMP_Text btnTextBulletSpeed;
    public TMP_Text currentFireSpeed;
    public TMP_Text btnTextFireSpeed;
    public Button btnFireSpeed;
    public Button btnBulletSpeed;
    public Button btnFirePower;

    public TMP_Text currentUpgradeLife;
    public TMP_Text btnTextUpgradeLife;
    public TMP_Text currentUpgradeMoney;
    public TMP_Text btnTextUpgradeMoney;
    public Button btnUpgradeLife;
    public Button btnUpgradeMoney;

    public Button btnDrone;
    private bool droneBought = false;
    public Button btnWall;
    private bool wallBought = false;

    public int MonsterWorthAdd = 0;

    //Upgrade price
    int FireSpeedPrice = 50;
    int BulletSpeedPrice = 20;
    int FirePowerPrice = 50;
    int LifePrice = 100;
    int MoneyPrice = 100;

    private void Update()
    {
        //Drone
        if (PlayerStats.Money < 5000 || droneBought == true)
        {
            btnDrone.interactable = false;
        } else
        {
            btnDrone.interactable = true;
        }
        //Wall
        if (PlayerStats.Money < 500 || wallBought == true)
        {
            btnWall.interactable = false;
        } else
        {
            btnWall.interactable = true;
        }


        //Gun Upgrade Update
        //FireSpeed
        currentFireSpeed.text = "FireSpeed -0.01<br>Current: " + Gun.TmBtSh.ToString("0.00") + "/s";
        btnTextFireSpeed.text = "Upgrade<br>" + FireSpeedPrice + " $";
        if (PlayerStats.Money < FireSpeedPrice)
        {
            btnFireSpeed.interactable = false;
        } else
        {
            btnFireSpeed.interactable = true;
        }
        //Bullet Speed
        currentBulletSpeed.text = "BulletSpeed +1<br>Current: " + Gun.BulletSpeed.ToString();
        btnTextBulletSpeed.text = "Upgrade<br>" + BulletSpeedPrice + " $";
        if (PlayerStats.Money < BulletSpeedPrice)
        {
            btnBulletSpeed.interactable = false;
        }
        else
        {
            btnBulletSpeed.interactable = true;
        }
        //FirePower
        currentFirePower.text = "FirePower +1<br>Current: " + Bullet.FirePower.ToString();
        btnTextFirePower.text = "Upgrade<br>" + FirePowerPrice + " $";
        if (PlayerStats.Money < FirePowerPrice)
        {
            btnFirePower.interactable = false;
        }
        else
        {
            btnFirePower.interactable = true;
        }


        //Player Upgrade Update
        //Life
        currentUpgradeLife.text = "Life +1<br>Current: " + PlayerStats.Lives.ToString();
        btnTextUpgradeLife.text = "Upgrade<br>" + LifePrice + " $";
        if (PlayerStats.Money < LifePrice)
        {
            btnUpgradeLife.interactable = false;
        }
        else
        {
            btnUpgradeLife.interactable = true;
        }
        //Money
        currentUpgradeMoney.text = "Money +1%<br>Current: " + MonsterWorthAdd.ToString() + "%";
        btnTextUpgradeMoney.text = "Upgrade<br>" + MoneyPrice + " $";
        if (PlayerStats.Money < MoneyPrice)
        {
            btnUpgradeMoney.interactable = false;
        }
        else
        {
            btnUpgradeMoney.interactable = true;
        }
    }

    //Gun Upgrades Function
    //FireSpeed
    public void BuyFireSpeed()
    {
        Debug.Log("Bought FireSpeed");
        PlayerStats.Money -= FireSpeedPrice;
        Gun.TmBtSh -= 0.01f;
        Debug.Log(Gun.TmBtSh);
        FireSpeedPrice += 10;
    }
    //BulletSpeed
    public void BuyBulletSpeed()
    {
        Debug.Log("Bought BulletSpeed");
        PlayerStats.Money -= BulletSpeedPrice;
        Gun.BulletSpeed += 1;
        Debug.Log(Gun.BulletSpeed);
        BulletSpeedPrice += 10;
    }
    //FirePower
    public void BuyFirePower()
    {
        Debug.Log("Bought FirePower");
        PlayerStats.Money -= FirePowerPrice;
        Bullet.FirePower += 1;
        Debug.Log(Bullet.FirePower);
        FirePowerPrice += 10;
    }

    //Player Upgrades Functions
    //Lives
    public void BuyLife()
    {
        Debug.Log("Bought Live");
        PlayerStats.Money -= LifePrice;
        PlayerStats.Lives += 1;
        Debug.Log(PlayerStats.Lives);
        LifePrice += 100;
    }
    //Money
    public void BuyMoney()
    {
        Debug.Log("Bought Money");
        PlayerStats.Money -= MoneyPrice;
        MonsterWorthAdd += 1;
        Monster.worth += MonsterWorthAdd;
        Debug.Log(MonsterWorthAdd);
        MoneyPrice += 100;
    }

    //Other Upgrades Function
    //Drone button
    public void BuyDrone() 
    {
        Debug.Log("Bought Drone " + droneBought);
        PlayerStats.Money -= 5000;
        droneBought = true;
    }

    //Wall button
    public void BuyWall()
    {
        Debug.Log("Bought Wall " + wallBought);
        PlayerStats.Money -= 500;
        wallBought = true;
        Instantiate(wallPrefab, new Vector3(-17.86f, -0.179f, 1.634f), Quaternion.Euler(0, 0, 0));
    }

    


}
