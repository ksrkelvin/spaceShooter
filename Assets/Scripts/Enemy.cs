using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int life = 3;
    [SerializeField] protected float speed = 3f;

    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected Transform shotPoint;
    [SerializeField] protected GameObject shotPrefab;

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
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);

        }
    }

}
