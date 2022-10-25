using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject dronePrefab;
    public int MonsterWorthAdd = 0;

    //Gun
    [Header("Gun")]
    public TMP_Text currentFirePower;
    public TMP_Text btnTextFirePower;
    public TMP_Text currentBulletSpeed;
    public TMP_Text btnTextBulletSpeed;
    public TMP_Text currentFireSpeed;
    public TMP_Text btnTextFireSpeed;
    public Button btnFireSpeed;
    public Button btnBulletSpeed;
    public Button btnFirePower;

    //Player
    [Header("Player")]
    public TMP_Text currentUpgradeLife;
    public TMP_Text btnTextUpgradeLife;
    public TMP_Text currentUpgradeMoney;
    public TMP_Text btnTextUpgradeMoney;
    public Button btnUpgradeLife;
    public Button btnUpgradeMoney;

    //Addon
    [Header("Addon")]
    public Button btnDrone;
    private bool droneBought = false;
    public Button btnWall;
    private bool wallBought = false;
    public Button btnLaserSight;
    private bool laserBought = false;

    //Upgrade price
    [Header("Price")]
    int FireSpeedPrice = 50;
    int BulletSpeedPrice = 20;
    int FirePowerPrice = 50;
    int LifePrice = 100;
    int MoneyPrice = 100;

    //Tab Selection
    [Header("Tab")]
    public GameObject GunUpgradeUI;
    public GameObject PlayerUpgradeUI;
    public GameObject AddonUI;

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
        //LaserSight
        if (PlayerStats.Money < 200 || laserBought == true)
        {
            btnLaserSight.interactable = false;
        }
        else
        {
            btnLaserSight.interactable = true;
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
        currentFirePower.text = "FirePower +2<br>Current: " + Bullet.FirePower.ToString();
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
        PlayerStats.Money -= FireSpeedPrice;
        Gun.TmBtSh -= 0.01f;
        FireSpeedPrice += 10;
    }
    //BulletSpeed
    public void BuyBulletSpeed()
    {
        PlayerStats.Money -= BulletSpeedPrice;
        Gun.BulletSpeed += 1;
        BulletSpeedPrice += 10;
    }
    //FirePower
    public void BuyFirePower()
    {
        PlayerStats.Money -= FirePowerPrice;
        Bullet.FirePower += 2;
        FirePowerPrice += 10;
    }

    //Player Upgrades Functions
    //Lives
    public void BuyLife()
    {
        PlayerStats.Money -= LifePrice;
        PlayerStats.Lives += 1;
        LifePrice += 100;
    }
    //Money
    public void BuyMoney()
    {
        PlayerStats.Money -= MoneyPrice;
        MonsterWorthAdd += 1;
        Monster.worth += MonsterWorthAdd;
        MoneyPrice += 100;
    }

    //Other Upgrades Function
    //Drone button
    public void BuyDrone() 
    {
        PlayerStats.Money -= 5000;
        droneBought = true;
        Instantiate(dronePrefab, new Vector3(-19.289f, 0.928f, 0.88f), Quaternion.Euler(0, 90, 0));
    }

    //Wall button
    public void BuyWall()
    {
        PlayerStats.Money -= 500;
        wallBought = true;
        Instantiate(wallPrefab, new Vector3(-18.06584f, 0.129f, 1.553496f), Quaternion.Euler(0, 87.588f, 0));
    }

    //LaserSight button
    public void BuyLaserSight()
    {
        PlayerStats.Money -= 200;
        laserBought = true;
        Gun.ActivateLaserSight();
    }

    //Tab Selection
    public void GunTabOpen()
    {
        if (GunUpgradeUI.activeSelf == false)
        {
            GunUpgradeUI.SetActive(true);
            PlayerUpgradeUI.SetActive(false);
            AddonUI.SetActive(false);
        }
    }
    public void PlayerTabOpen()
    {
        if (PlayerUpgradeUI.activeSelf == false)
        {
            GunUpgradeUI.SetActive(false);
            PlayerUpgradeUI.SetActive(true);
            AddonUI.SetActive(false);
        }
    }
    public void AddonTabOpen()
    {
        if (AddonUI.activeSelf == false)
        {
            GunUpgradeUI.SetActive(false);
            PlayerUpgradeUI.SetActive(false);
            AddonUI.SetActive(true);
        }
    }


}
