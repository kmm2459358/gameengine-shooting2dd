using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTyuBossBigController : MonoBehaviour
{
    public float sin;
    public float cos;
    public GameObject small;
    GameObject go;
    float span = 0.1f;
    float delta = 0;

    void Update()
    {
        transform.Translate(sin / 9, cos / 9, 0);

        //ショット
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            SmallBulletAdd();
        }

        //画面外で消す
        if (this.transform.position.y < -4f ||
            this.transform.position.y > 6f ||
            this.transform.position.x < -3f ||
            this.transform.position.x > 3f)
        {
            Destroy(gameObject);
        }
    }

    void SmallBulletAdd()
    {
        go = Instantiate(small);
        var pos = this.gameObject.transform.position;

        go.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ult")
            Destroy(gameObject);
    }
}
