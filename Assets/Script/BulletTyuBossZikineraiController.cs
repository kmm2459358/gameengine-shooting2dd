using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTyuBossZikineraiController : MonoBehaviour
{
    GameObject player;
    float sin = 0f;
    float cos = 0f;
    float sins = 0f;
    float coss = 0f;
    float px = 0.0f;
    float py = -1.0f;
    int j = 0;
    float teisi = 0;

    void Start()
    {
        //Debug.Log("sin" + sin);
        //Debug.Log("cos" + cos);
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(sins / 10, coss / 10, 0);

        //êiÇ›ÇæÇ∑
        this.teisi += Time.deltaTime;
        if (this.teisi > 3f && j == 0)
        {
            j++;
            EnemyShoot();
        }

        if (this.teisi > 3f && j == 1)
        {
            sins += sin * 0.01f;
            coss += cos * 0.01f;
            if (this.teisi > 6.5f && j == 1)
            {
                j++;
                teisi = 0;
            }
        }

        //âÊñ äOÇ≈è¡Ç∑
        if (this.transform.position.y < -3.6f ||
            this.transform.position.y > 6f ||
            this.transform.position.x < -3f ||
            this.transform.position.x > 3f)
        {
            Destroy(gameObject);
        }
    }

    void EnemyShoot()
    {
        var pos = this.gameObject.transform.position;
        var posP = player.transform.position;

        posP.y -= 0.28f;
        if (posP.x > 2.1954f)
        {
            posP.x = 2.1954f;
        }
        if (posP.x < -2.1954f)
        {
            posP.x = -2.1954f;
        }
        if (posP.y > 4.6664f)
        {
            posP.y = 4.6664f;
        }
        if (posP.y < -3f)
        {
            posP.y = -3f;
        }
        //Debug.Log("x" + posP.x);
        //Debug.Log("y" + posP.y);
        px = posP.x - pos.x;
        py = posP.y - pos.y;

        float pxx;
        float pyy;

        if (px < 0.0f)
            pxx = px * -1.0f;
        else
            pxx = px;
        if (py < 0.0f)
            pyy = py * -1.0f;
        else
            pyy = py;

        sin = px / (pxx + pyy);
        cos = py / (pxx + pyy);
    }

        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ult")
            Destroy(gameObject);
    }
}
