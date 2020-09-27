using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Slider shootSpeed;
    public Slider playerSpeed;
    public Slider fireRate;
    public Toggle showMenu;
    public Text showMenuText;

    public Text bulletValue;
    public Text speedValue;
    public Text rateValue;

    public Text totalKills;
    public Text selfKill;
    public Text deathsText;
    public Text longestTimeInGame;

    int score;
    int selfKills;
    int deaths;
    float secs;
    int min;
    int hour;
    bool timeSet;

    bool showMenuOnDeath = true;
    // Start is called before the first frame update
    void Start()
    {
        fireRate.value = PlayerPrefs.GetInt("FireRate");
        shootSpeed.value = PlayerPrefs.GetInt("ShootSpeed");
        playerSpeed.value = PlayerPrefs.GetInt("Power");

        bulletValue.text = shootSpeed.value.ToString();
        rateValue.text = fireRate.value.ToString();
        speedValue.text = playerSpeed.value.ToString();

        score = PlayerPrefs.GetInt("Score");
        totalKills.text = "Total Kills: " + score.ToString();

        selfKills = PlayerPrefs.GetInt("SelfKills");
        selfKill.text = "Self Kills: " + selfKills.ToString();

        deaths = PlayerPrefs.GetInt("Deaths");
        deathsText.text = "Deaths: " + deaths.ToString();

        secs = PlayerPrefs.GetFloat("Seconds");

        int i = PlayerPrefs.GetInt("ShowMenuOnDeath");
        Debug.Log(i);
        if (i == 0)
        {
            showMenu.isOn = false;
        }
        else
        {
            showMenu.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        while (!timeSet)
        {
            min = (int)secs / 60;
            secs = (int)secs - 60 * min;

            if (min / 60 >= 1)
            {
                hour++;
                min -= 60;
            }
            else if (min / 60 < 1)
            {
                timeSet = true;
            }

            longestTimeInGame.text = string.Format("Longest Time In Game: {0:00} : {1:00} : {2:00}", hour, min, secs);
        }
    }

    public void IncreaseShootSpeed()
    {
        shootSpeed.value++;
        bulletValue.text = shootSpeed.value.ToString();
        PlayerPrefs.SetInt("ShootSpeed", (int)shootSpeed.value);
    }

    public void DecreaseShootSpeed()
    {
        shootSpeed.value--;
        bulletValue.text = shootSpeed.value.ToString();
        PlayerPrefs.SetInt("ShootSpeed", (int)shootSpeed.value);
    }

    public void IncreaseFireRate()
    {
        fireRate.value++;
        rateValue.text = fireRate.value.ToString();
        PlayerPrefs.SetInt("FireRate", (int)fireRate.value);
    }

    public void DecreaseFireRate()
    {
        fireRate.value--;
        rateValue.text = fireRate.value.ToString();
        PlayerPrefs.SetInt("FireRate", (int)fireRate.value);
    }

    public void IncreaseSpeed()
    {
        playerSpeed.value++;
        speedValue.text = playerSpeed.value.ToString();
        PlayerPrefs.SetInt("Power", (int)playerSpeed.value);
    }

    public void DecreaseSpeed()
    {
        playerSpeed.value--;
        speedValue.text = playerSpeed.value.ToString();
        PlayerPrefs.SetInt("Power", (int)playerSpeed.value);
    }

    public void ResetStats()
    {
        shootSpeed.value = 1;
        bulletValue.text = shootSpeed.value.ToString();
        PlayerPrefs.SetInt("ShootSpeed", (int)shootSpeed.value);
        fireRate.value = 1;
        rateValue.text = fireRate.value.ToString();
        PlayerPrefs.SetInt("FireRate", (int)fireRate.value);
        playerSpeed.value = 1;
        speedValue.text = playerSpeed.value.ToString();
        PlayerPrefs.SetInt("Power", (int)playerSpeed.value);

        PlayerPrefs.SetInt("Score", 0);
        score = PlayerPrefs.GetInt("Score");
        totalKills.text = "Total Kills: " + score.ToString();

        PlayerPrefs.SetInt("SelfKills", 0);
        selfKills = PlayerPrefs.GetInt("SelfKills");
        selfKill.text = "Self Kills: " + selfKills.ToString();

        PlayerPrefs.SetInt("Deaths", 0);
        deaths = PlayerPrefs.GetInt("Deaths");
        deathsText.text = "Deaths: " + deaths.ToString();

        PlayerPrefs.SetFloat("Seconds", 0);
        longestTimeInGame.text = "Longest Time In Game: 00 : 00 : 00";
    }

    public void ToggleShowMenuOnDeath()
    {
        if (showMenuOnDeath == true)
        {
            showMenuOnDeath = false;
        }
        else if (showMenuOnDeath == false)
        {
            showMenuOnDeath = true;
        }

        if (showMenuOnDeath)
        {
            PlayerPrefs.SetInt("ShowMenuOnDeath", 1);
        }
        else if (!showMenuOnDeath)
        {
            PlayerPrefs.SetInt("ShowMenuOnDeath", 0);
        }
    }
}
