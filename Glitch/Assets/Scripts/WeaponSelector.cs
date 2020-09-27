using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    public List<GameObject> weapons;

    public List<GameObject> homeWeapon;
    public Text homeWeaponText;

    public Skins skins;

    int index;

    int hasSavedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        hasSavedWeapon = PlayerPrefs.GetInt("hasSavedWeapon");
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
            homeWeapon[i].SetActive(false);
        }
        if (hasSavedWeapon == 0)
        {
            PlayerPrefs.SetInt("LastSavedWeapon", 0);
            hasSavedWeapon = 1;
            PlayerPrefs.SetInt("hasSavedWeapon", 1);
            homeWeapon[0].SetActive(true);
        }
        else
        {
            int lastSavedWeapon = PlayerPrefs.GetInt("LastSavedWeapon");
            for (int i = 0; i < weapons.Count; i++)
            {
                if (i == lastSavedWeapon)
                {
                    homeWeapon[lastSavedWeapon].SetActive(true);
                    homeWeaponText.text = homeWeapon[i].gameObject.name;
                }
                else if (i == 0)
                {
                    weapons[i].SetActive(true); 
                    homeWeapon[lastSavedWeapon].SetActive(true);
                    homeWeaponText.text = homeWeapon[i].gameObject.name;
                }
                else
                {
                    weapons[i].SetActive(false);
                    homeWeapon[i].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        index++;
        if (index > weapons.Count - 1)
        {
            index = 0;
        }
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == index)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }

    public void Back()
    {
        index--;
        if (index < 0)
        {
            index = weapons.Count - 1;
        }
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == index)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }

    public void SelectWeapon()
    {
        PlayerPrefs.SetInt("Weapon", index);
        PlayerPrefs.SetInt("LastSavedWeapon", index);
        for (int i = 0; i < homeWeapon.Count; i++)
        {
            if (i == index)
            {
                homeWeapon[i].SetActive(true);
            }
            else
            {
                homeWeapon[i].SetActive(false);
            }
        }
        homeWeapon[index].GetComponent<SpriteRenderer>().color = skins.color;
        homeWeaponText.text = weapons[index].gameObject.name;
    }
}
