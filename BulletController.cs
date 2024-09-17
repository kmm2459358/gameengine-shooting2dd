using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletZikineraiController : MonoBehaviour
{
    public float sin = 0f;
    public float cos = 0f;

    void Start()
    {
        //Debug.Log("sin" + sin);
        //Debug.Log("cos" + cos);
    }

    void Update()
    {
        transform.Translate(sin / 100, cos / 100, 0);

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
