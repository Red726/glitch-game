using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Player playerScript;

    Vector3 originPoint;
    public GameObject player;
    public float radius = 20f;

    public GameObject[] gameObjects;
    GameObject[] bytes;
    public int maxBytes;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        if (player)
        {
            originPoint = player.transform.position;
            originPoint.x += Random.Range(-radius, radius);
            originPoint.y += Random.Range(-radius, radius);

            bytes = GameObject.FindGameObjectsWithTag("Byte");
            if (bytes.Length <= maxBytes)
            {
                if (playerScript.score <= 30)
                {
                    maxBytes = 15;
                    radius = 50;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 2.25f);
                }
                else if (playerScript.score <= 50)
                {
                    maxBytes = 20;
                    radius = 45;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 2.20f);
                }
                else if (playerScript.score <= 75)
                {
                    maxBytes = 20;
                    radius = 40;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 2.15f);
                }
                else if (playerScript.score <= 100)
                {
                    maxBytes = 25;
                    radius = 35;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 2.1f);
                }
                else if (playerScript.score <= 200)
                {
                    maxBytes = 30;
                    radius = 30;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 2.05f);
                }
                else if (playerScript.score <= 500)
                {
                    maxBytes = 35;
                    radius = 25;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 2f);
                }
                else if (playerScript.score <= 750)
                {
                    maxBytes = 40;
                    radius = 20;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 1.75f);
                }
                else if (playerScript.score <= 1000)
                {
                    maxBytes = 45;
                    radius = 15;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 1.5f);
                }
                else if (playerScript.score >= 1000)
                {
                    maxBytes = 50;
                    radius = 10;
                    InvokeRepeating("SpawnEnemyTime", 1.5f, 1.25f);
                }
            }
            else
            {
                CancelInvoke("SpawnEnemyTime");
            }
        }
    }

    void SpawnEnemyTime()
    {
        if (playerScript.score <= 30)
        {
            index = Random.Range(0, 8);
            if (index > 4)
            {
                index = 0;
            }
        }
        else if (playerScript.score <= 50)
        {
            index = Random.Range(0, 8);
            if (index >= 4)
            {
                index = 1;
            }
        }
        else if (playerScript.score <= 75)
        {
            index = Random.Range(0, 8);
            if (index >= 4)
            {
                index = 2;
            }
        }
        else if (playerScript.score <= 100)
        {
            index = Random.Range(0, 8);
            if (index >= 4)
            {
                index = 3;
            }
        }
        else if (playerScript.score <= 200)
        {
            index = Random.Range(0, 8);
            if (index >= 7)
            {
                index = 4;
            }
        }
        else if (playerScript.score <= 500)
        {
            index = Random.Range(0, 8);
            if (index >= 7)
            {
                index = 5;
            }
        }
        else if (playerScript.score <= 750)
        {
            index = Random.Range(0, 8);
        }
        else if (playerScript.score <= 1000)
        {
            index = Random.Range(0, 8);
        }
        else if (playerScript.score > 1000)
        {
            index = Random.Range(0, 8);
        }

        StartCoroutine(SpawnEnemy(index));
    }

    IEnumerator SpawnEnemy(int i)
    {
        yield return null;
        Instantiate(gameObjects[i], originPoint, transform.rotation);
        CancelInvoke("SpawnEnemyTime");
    }
}