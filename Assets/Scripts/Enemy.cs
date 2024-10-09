using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int life = 3;
    [SerializeField] protected float speed = 3f;

    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected GameObject explosionPrefab;

    [SerializeField] protected GameObject shotPrefab;
    [SerializeField] protected int xp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //Receive damage
    public void OnDamage(int damage)
    {
        if (transform.position.y <= 5f)
        {
            life -= damage;
            if (life <= 0)
            {
                Destroy(gameObject);
                Instantiate(explosionPrefab, transform.position, transform.rotation);

                EnemyGen enemyGen = FindObjectOfType<EnemyGen>();
                enemyGen.RemoveEnemy();
                enemyGen.AddXP(xp);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            EnemyGen enemyGen = FindObjectOfType<EnemyGen>();
            enemyGen.RemoveEnemy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            EnemyGen enemyGen = FindObjectOfType<EnemyGen>();
            enemyGen.RemoveEnemy();
            collision.gameObject.GetComponent<PlayerController>().OnDamage(1);

        }
    }

}
