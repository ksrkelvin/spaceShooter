using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotController : MonoBehaviour
{

    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject shotImpactPrefab;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(shotImpactPrefab, transform.position, transform.rotation);

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().OnDamage(damage);
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().OnDamage(damage);
        }

        

        
    }

}
