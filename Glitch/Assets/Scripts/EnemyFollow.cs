using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject particle;
    public GameObject firePoint;
    public GameObject bullet;

    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        soundManager = player.GetComponentInChildren<SoundManager>();

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.up = player.position - transform.position;

            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                Shoot(gameObject.name);
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    void Shoot(string name)
    {
        var newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        newBullet.gameObject.GetComponent<Bullet>().BulletName(name);
        timeBtwShots = startTimeBtwShots;
        soundManager.Gunshot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject newParticle = Instantiate(particle, transform.position, transform.rotation);
        Destroy(newParticle, .5f);

        soundManager.PlayImpact();
    }
}
