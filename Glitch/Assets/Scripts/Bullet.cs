using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player player;
    float speed;
    Rigidbody2D rb;
    public GameObject particle;
    public SceneManage sceneManager;
    public SoundManager soundManager;

    public Sprite[] sprites;
    public Sprite[] weaponSprites;
    int weaponIndex;

    public bool playerBullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        soundManager = player.GetComponentInChildren<SoundManager>();
        sceneManager = player.GetComponentInChildren<SceneManage>();
        weaponIndex = player.weaponIndex;
        if (gameObject.GetComponent<PolygonCollider2D>() == null)
        {
            gameObject.AddComponent<PolygonCollider2D>();
        }
        
        StartCoroutine(DestroyAfterSeconds(15f));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed * 90 * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != player && collision.gameObject != player.weapon)
        {
            var newParticle = Instantiate(particle, transform.position, transform.rotation);
            StartCoroutine(StopCollisionParticles(newParticle));

            soundManager.PlayImpact();
        }

        if (gameObject.name == "playerBullet")
        {
            if (collision.gameObject.name == "Byte")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Megabyte(Clone)")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Gigabyte(Clone)")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Terabyte(Clone)")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Petabyte(Clone)")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Exabyte(Clone)")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Zettabyte(Clone)")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Yottabyte(Clone)")
            {
                player.score++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
            else if (collision.gameObject.name == "Player")
            {
                player.selfKills++;
                PlayerPrefs.SetInt("SelfKills", player.selfKills);
            }
            PlayerPrefs.SetInt("Score", player.score);
        }
        else
        {
            if (collision.gameObject.name == "Player")
            {
                player.deaths++;
                PlayerPrefs.SetInt("Deaths", player.deaths);
                if (player.ShowMenuOnDeath)
                {
                    Debug.Log("Player died");
                    StopAllCoroutines();
                    collision.gameObject.SetActive(false);
                    Invoke("LoadMenu", 3);
                }
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Destroy(GetComponent<PolygonCollider2D>());
            }
        }
    }

    void LoadMenu()
    {
        sceneManager.Menu();
        Debug.Log("Loading Menu");
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(GetComponent<PolygonCollider2D>());
        Destroy(this.gameObject);
    }

    IEnumerator StopCollisionParticles(GameObject particle)
    {
        yield return new WaitForSeconds(.4f);
        Destroy(particle);
    }

    public void BulletName(string name)
    {
        if (name == "Byte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            speed = 10;
            playerBullet = false;

        }
        else if (name == "Megabyte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            speed = 12;
            playerBullet = false;
        }
        else if (name == "Gigabyte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
            speed = 14;
            playerBullet = false;
        }
        else if (name == "Terabyte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
            speed = 16;
            playerBullet = false;
        }
        else if (name == "Petabyte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
            speed = 18;
            playerBullet = false;
        }
        else if (name == "Exabyte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
            speed = 20;
            playerBullet = false;
        }
        else if (name == "Zettabyte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
            speed = 22;
            playerBullet = false;
        }
        else if (name == "Yottabyte(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
            speed = 24;
            playerBullet = false;
        }
        else if (name == "Player")
        {
            playerBullet = true;
            gameObject.name = "playerBullet";
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponSprites[weaponIndex];
            speed = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().shootSpeed;
        }
    }
}