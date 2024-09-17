using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBulletController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jampforce = 120f;

    void Start()
    {
        float kakudo = Random.Range(-300, 301) / 10;
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo);

        this.rigid2D = GetComponent<Rigidbody2D>();

        this.rigid2D.AddForce(transform.up * this.jampforce);
    }

    void Update()
    {
        //âÊñ äOÇ≈è¡Ç∑
        if (this.transform.position.y < -4f ||
            this.transform.position.y > 6f ||
            this.transform.position.x < -3f ||
            this.transform.position.x > 3f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
