using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public Image healthBarWall;
    public  float startHealthWall = 100;
    private float wallHealth;

    // Start is called before the first frame update
    void Start()
    {
        wallHealth = startHealthWall;
    }

    public void TakeDamageFromMonster(int amountTaken)
    {
        wallHealth -= amountTaken;
        healthBarWall.fillAmount = wallHealth / startHealthWall;
        if (wallHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
