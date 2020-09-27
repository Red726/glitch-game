using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public List<GameObject> skins;
    public List<Sprite> sprites;

    public GameObject homeSkin;
    public Text homeSkinText;

    public WeaponSelector weapons;

    int index;
    int colorIndex;
    string colorName;
    public Color color;
    int hasSavedColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        hasSavedColor = PlayerPrefs.GetInt("hasSavedColor");
        if (hasSavedColor == 0)
        {
            color = new Color(255, 255, 255);
            PlayerPrefs.SetString("LastSavedColor", "White");
            hasSavedColor = 1;
            PlayerPrefs.SetInt("hasSavedColor", 1);
        }
        else
        {
            int lastSavedSkin = PlayerPrefs.GetInt("LastSavedSkin");
            homeSkin.GetComponent<SpriteRenderer>().sprite = skins[lastSavedSkin].GetComponent<SpriteRenderer>().sprite;
            homeSkinText.text = homeSkin.GetComponent<SpriteRenderer>().sprite.name;
            StartColor();
        }
        for (int i = 0; i < skins.Count; i++)
        {
            skins[i].GetComponent<SpriteRenderer>().color = color;
            if (i == 0)
            {
                skins[i].SetActive(true);
            }
            else
            {
                skins[i].SetActive(false);
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
        if (index > skins.Count - 1)
        {
            index = 0;
        }
        for (int i = 0; i < skins.Count; i++)
        {
            if (i == index)
            {
                skins[i].SetActive(true);
            }
            else
            {
                skins[i].SetActive(false);
            }
        }
    }

    public void Back()
    {
        index--;
        if (index < 0)
        {
            index = skins.Count - 1;
        }
        for (int i = 0; i < skins.Count; i++)
        {
            if (i == index)
            {
                skins[i].SetActive(true);
            }
            else
            {
                skins[i].SetActive(false);
            }
        }
    }

    public void SelectSkin()
    {
        PlayerPrefs.SetInt("Skin", index);
        homeSkin.GetComponent<SpriteRenderer>().sprite = sprites[index];
        homeSkin.GetComponent<SpriteRenderer>().color = color;
        for (int i = 0; i < weapons.homeWeapon.Count; i++)
        {
            weapons.homeWeapon[i].GetComponent<SpriteRenderer>().color = color;
            weapons.homeWeapon[i].GetComponentInChildren<SpriteRenderer>().color = color;
        }
        homeSkinText.text = skins[index].gameObject.name;
        PlayerPrefs.SetInt("LastSavedSkin", index);
    }

    public void SelectColor(string name)
    {
        colorName = name;
        PlayerPrefs.SetString("LastSavedColor", colorName);
        ChangeColor();
    }

    void StartColor()
    {
        colorName = PlayerPrefs.GetString("LastSavedColor");
        ChangeColor();
    }

    public void ChangeColor()
    {
        
        if (colorName == "Red")
        {
            colorIndex = 0;
            color = new Color32(255, 0, 0, 255);
        }
        else if (colorName == "Red (1)")
        {
            colorIndex = 1;
            color = new Color32(123, 0, 0, 255);
        }
        else if (colorName == "Red (2)")
        {
            colorIndex = 2;
            color = new Color32(176, 0, 0, 255);
        }
        else if (colorName == "Red (3)")
        {
            colorIndex = 3;
            color = new Color32(154, 0, 0, 255);
        }
        else if (colorName == "Grey")
        {
            colorIndex = 4;
            color = new Color32(135, 135, 135, 255);
        }
        else if (colorName == "Grey (1)")
        {
            colorIndex = 5;
            color = new Color32(75, 75, 75, 255);
        }
        else if (colorName == "Grey (2)")
        {
            colorIndex = 6;
            color = new Color32(45, 45, 45, 255);
        }
        else if (colorName == "White")
        {
            colorIndex = 7;
            color = new Color32(255, 255, 255, 255);
        }
        for (int i = 0; i < skins.Count; i++)
        {
            skins[i].GetComponent<SpriteRenderer>().color = color;
        }
        for (int i = 0; i < weapons.homeWeapon.Count; i++)
        {
            weapons.homeWeapon[i].GetComponent<SpriteRenderer>().color = color;
        }
        for (int i = 0; i < weapons.weapons.Count; i++)
        {
            weapons.weapons[i].GetComponent<SpriteRenderer>().color = color;
        }
        homeSkin.GetComponent<SpriteRenderer>().color = color;
        PlayerPrefs.SetInt("Color", colorIndex);
    }
}