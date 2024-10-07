using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : Enemy
{

    private Rigidbody2D rb;
    [SerializeField] protected Transform shotPoint;
    [SerializeField] private float shotSpeed = 5f;
    [SerializeField] private float yLimit = 2.5f;
    private bool isMoving = false;
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
        if (!isMoving)
        {
            rb.velocity = new Vector2(0, -speed);
            if (transform.position.y < yLimit)
            {
                rb.velocity = new Vector2(0, -speed);
                if (transform.position.x < 0)
                {
                    isMoving = true;
                    rb.velocity = new Vector2(speed, -speed);
                }
                else
                {
                    isMoving = true;
                    rb.velocity = new Vector2(-speed, -speed);
                }
            }
        }




    }

    public void Shooting()
    {


        var isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;
        if (isVisible)
        {
            //encontrando o player
            var player = GameObject.FindObjectOfType<PlayerController>();
            if (player != null)
            {
                fire -= Time.deltaTime;
                if (fire <= 0)
                {
                    var enemyShot = Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation);
                    //calculando a direção do tiro
                    var direction = player.transform.position - enemyShot.transform.position;
                    direction.Normalize();
                    //adicionando velocidade ao tiro
                    enemyShot.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;
                    //corrigindo a rotação do tiro
                    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    enemyShot.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
                    fire = Random.Range(fireRate, 2 * fireRate);
                }
            }
        }

    }

}
