using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    public Rigidbody2D rb;
    public float power = 15f;
    public GameObject bullet;
    Bullet bulletScript;
    GameObject firePoint;
    public GameObject particle;
    public GameObject currentBullet;
    public GameObject weapon;

    public TimeManager timeManager;
    public TimeBody timeBody;
    public SceneManage sceneManage;
    public SoundManager sound;

    public Sprite[] playerSprites;
    public Sprite[] playerWeapons;
    public Color32[] playerColors;

    public int weaponIndex;

    public float shootSpeed = 8;
    public float fireRate = 15f;
    bool allowFire = true;

    public bool moving;

    private float secsCount;
    public float bestTime;

    public int score;
    public int selfKills;
    public int deaths;

    public bool ShowMenuOnDeath;

    void Start()
    {
        int spriteIndex = PlayerPrefs.GetInt("Skin");
        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[spriteIndex];
        int colorIndex = PlayerPrefs.GetInt("Color");
        gameObject.GetComponent<SpriteRenderer>().color = playerColors[colorIndex];
        weaponIndex = PlayerPrefs.GetInt("Weapon");
        weapon.GetComponent<SpriteRenderer>().sprite = playerWeapons[weaponIndex];
        weapon.GetComponent<SpriteRenderer>().color = playerColors[colorIndex];
        firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        fireRate = PlayerPrefs.GetInt("FireRate");
        shootSpeed = PlayerPrefs.GetInt("ShootSpeed");
        power = PlayerPrefs.GetInt("Power");
        secsCount = 0;
        score = PlayerPrefs.GetInt("Score");
        selfKills = PlayerPrefs.GetInt("SelfKills");
        deaths = PlayerPrefs.GetInt("Deaths");
        bestTime = PlayerPrefs.GetFloat("Seconds");

        int menuOnDeath = PlayerPrefs.GetInt("ShowMenuOnDeath");
        if (menuOnDeath == 0)
        {
            ShowMenuOnDeath = false;
        }
        else if (menuOnDeath == 1)
        {
            ShowMenuOnDeath = true;
        }
        Debug.Log(ShowMenuOnDeath);
        Invoke("RewindTimeRandomly", 6);
    }

    void Update()
    {
        UpdateTimer();

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            moving = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward * 20, -mousePos - transform.position);
            moving = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            direction = startPos - endPos;
            rb.isKinematic = false;
            rb.AddForce(direction * power);
            StartCoroutine(SlowDownPlayer(2));
        }
        if (moving == false)
        {
            rb.velocity = rb.velocity *= .95f;
        }

        if (Input.GetKey(KeyCode.F) && allowFire)
        {
            StartCoroutine(Shoot(fireRate));
            allowFire = true;
            sound.Gunshot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            sceneManage.Menu();
        }
    }

    void UpdateTimer()
    {
        secsCount += Time.unscaledDeltaTime;
        if (secsCount > bestTime)
        {
            bestTime = secsCount;
            PlayerPrefs.SetFloat("Seconds", bestTime);
        }
    }

    IEnumerator SlowDownPlayer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        moving = false;
        StopCoroutine("SlowDownPlayer");
    }

    void RewindTimeRandomly()
    {
        timeBody.StartRewind();
        float randomTime = Random.Range(1, 25);
        Invoke("RewindTimeRandomly", randomTime);
    }

    IEnumerator Shoot(float waitTime)
    {
        allowFire = false;
        var newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        bulletScript = newBullet.GetComponent<Bullet>();
        bulletScript.BulletName("Player");
        currentBullet = newBullet;

        int randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            timeManager.DoSlowmotion();
        }
        else if (randNum == 1)
        {
            timeManager.SpeedUpTime();
        }
        else if (randNum == 2)
        {
            timeBody.StartRewind();
        }
        yield return new WaitForSeconds(waitTime / 60);
    }
}
