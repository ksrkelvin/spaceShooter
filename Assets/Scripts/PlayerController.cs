using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life = 3;

    //Movement
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;

    //Shooting
    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float shotSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    public void Move()
    {

        Vector2 newVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        newVelocity.Normalize();
        rb.velocity = newVelocity * speed;


    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var playerShot  = Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation);
            playerShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shotSpeed);
        }
    }

    public void OnDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
