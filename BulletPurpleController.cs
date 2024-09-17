using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPurpleController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, -0.035f, 0);

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