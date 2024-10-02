using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalletController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0f, 0.6f, 0f);

        if (this.transform.position.y > 5.1f) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
