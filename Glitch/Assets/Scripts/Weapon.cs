using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Player player;
    public GameObject particle;
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<PolygonCollider2D>() != null)
        {
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        soundManager = player.GetComponentInChildren<SoundManager>();

        if (gameObject.GetComponent<PolygonCollider2D>() == null)
        {
            gameObject.AddComponent<PolygonCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            var newParticle = Instantiate(particle, transform.position, transform.rotation);
            StartCoroutine(StopCollisionParticles(newParticle));

            soundManager.PlayImpact();
        }
    }

    IEnumerator StopCollisionParticles(GameObject particle)
    {
        yield return new WaitForSeconds(.4f);
        Destroy(particle);
    }
}
