using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    SpriteRenderer spriteRend;

    EnemyFollow enemyFollow;
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = this.gameObject.GetComponent<SpriteRenderer>();
        enemyFollow = this.gameObject.GetComponent<EnemyFollow>();

        if (spriteRend.sprite.name == "Byte")
        {
            Byte();
        }
        if (spriteRend.sprite.name == "Megabyte")
        {
            Megabyte();
        }
        if (spriteRend.sprite.name == "Gigabyte")
        {
            Gigabyte();
        }
        if (spriteRend.sprite.name == "Terabyte")
        {
            Terabyte();
        }
        if (spriteRend.sprite.name == "Petabyte")
        {
            Petabyte();
        }
        if (spriteRend.sprite.name == "Exabyte")
        {
            Exabyte();
        }
        if (spriteRend.sprite.name == "Zettabyte")
        {
            Zettabyte();
        }
        if (spriteRend.sprite.name == "Yottabyte")
        {
            Yottabyte();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Byte()
    {
        enemyFollow.speed = 1.5f;
        enemyFollow.stoppingDistance = .75f;
        enemyFollow.retreatDistance = .85f;
    }

    void Megabyte()
    {
        enemyFollow.speed = 2.0f;
        enemyFollow.stoppingDistance = .75f;
        enemyFollow.retreatDistance = .85f;
    }

    void Gigabyte()
    {
        enemyFollow.speed = 3.5f;
        enemyFollow.stoppingDistance = .5f;
        enemyFollow.retreatDistance = .6f;
    }

    void Terabyte()
    {
        enemyFollow.speed = 4.0f;
        enemyFollow.stoppingDistance = .5f;
        enemyFollow.retreatDistance = .6f;
    }

    void Petabyte()
    {
        enemyFollow.speed = 5.5f;
        enemyFollow.stoppingDistance = .25f;
        enemyFollow.retreatDistance = .35f;
    }

    void Exabyte()
    {
        enemyFollow.speed = 6.0f;
        enemyFollow.stoppingDistance = .25f;
        enemyFollow.retreatDistance = .35f;
    }

    void Zettabyte()
    {
        enemyFollow.speed = 7.5f;
        enemyFollow.stoppingDistance = .15f;
        enemyFollow.retreatDistance = .25f;
    }

    void Yottabyte()
    {
        enemyFollow.speed = 8.0f;
        enemyFollow.stoppingDistance = .15f;
        enemyFollow.retreatDistance = .25f;
    }
}
