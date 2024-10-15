using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private int shotLevel = 1;

    //Movement
    [SerializeField] private float xLimit = 8.3f;
    [SerializeField] private float yLimit = 4.4f;
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;

    //Shooting
    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private GameObject shot2Prefab;
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

        float x = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float y = Mathf.Clamp(transform.position.y, -yLimit, yLimit);

        transform.position = new Vector2(x, y);

    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            switch (shotLevel)
            {
                case 1:
                    SetShot(shotPrefab, shotPoint.position);
                    break;

                case 2:
                    SetShot(shotPrefab, transform.position + new Vector3(0.5f, 0.1f, 0));
                    SetShot(shotPrefab, transform.position + new Vector3(-0.5f, 0.1f, 0));
                    break;
                case 3:
                    SetShot(shotPrefab, transform.position + new Vector3(0.5f, 0.1f, 0));
                    SetShot(shot2Prefab, transform.position + new Vector3(0, 0.2f, 0));
                    SetShot(shotPrefab, transform.position + new Vector3(-0.5f, 0.1f, 0));
                    break;
                case 4:
                    SetShot(shot2Prefab, transform.position + new Vector3(0.5f, 0.1f, 0));
                    SetShot(shotPrefab, transform.position + new Vector3(0, 0.2f, 0));
                    SetShot(shot2Prefab, transform.position + new Vector3(-0.5f, 0.1f, 0));
                    break;
                case 5:
                    SetShot(shot2Prefab, transform.position + new Vector3(0.5f, 0.1f, 0));
                    SetShot(shot2Prefab, transform.position + new Vector3(0, 0.2f, 0));
                    SetShot(shot2Prefab, transform.position + new Vector3(-0.5f, 0.1f, 0));
                    break;

            }

        }
    }

    private void SetShot(GameObject shotPrefeb, Vector3 position)
    {
        var shot = Instantiate(shotPrefeb, position, transform.rotation);
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shotSpeed);
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
