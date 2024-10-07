using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    private Rigidbody2D rb;

    [SerializeField] protected Transform shotPoint;
    [SerializeField] private float shotSpeed = 5f;
    private float fire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fire = Random.Range(0.5f, fireRate);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shooting();


    }

    public void Move()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    public void Shooting()
    {

        //Verificando se sprite render is visible 
        var isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (isVisible)
        {
            fire -= Time.deltaTime;
            if (fire <= 0)
            {
                var enemyShot = Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation);
                enemyShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -shotSpeed);
                fire = Random.Range(fireRate, 2 * fireRate);
            }

        }

    }



}
