using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Movement
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;

    //Shooting
    [SerializeField] private GameObject shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    public void Inputs()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    public void Move()
    {

        Vector2 newVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        newVelocity.Normalize();
        rb.velocity = newVelocity * speed;


    }

    public void Shoot()
    {
        GameObject shot = Instantiate(shotPrefab, transform.position, transform.rotation);
        
    }

}
