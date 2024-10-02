using UnityEngine;

public class EnergyItemController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jampforce = 80f;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();

        this.rigid2D.AddForce(transform.up * this.jampforce);
    }

    void Update()
    {
        if (this.transform.position.y < -4f)
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
