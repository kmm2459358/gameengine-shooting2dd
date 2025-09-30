using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPurpleSuraimuController : MonoBehaviour
{
    //プレイヤーオブジェクト
    GameObject player;
    //弾のプレハブオブジェクト
    public GameObject RedBulletPrefab;
    GameObject go;
    int j = 0;
    int shot = 0;
    float teisi = 0;
    float speed = -0.08f;
    float span = 1.6f;
    float delta = 0;
    float px = 0.0f;
    float py = -1.0f;
    int HP = 50;
    GameObject audi;

    void Start()
    {
        player = GameObject.Find("Player");
        audi = GameObject.Find("AudioSourceDirector");

        teisi = 0;
    }

    void Update()
    {
        //飛び出てくる
        transform.Translate(0f, speed, 0);
        this.teisi += Time.deltaTime;
        if (this.teisi > 0.6f && j == 0)
        {
            speed += 0.003f;
            if (this.teisi > 1.05f && j == 0)
            {
                j++;
                teisi = 0;
                speed = 0;
            }
        }

        //進みだす
        if (this.teisi > 0.6f && j == 1)
        {
            speed -= 0.004f;
            if (this.teisi > 1.1f && j == 1)
            {
                j++;
                teisi = 0;
            }
        }

        //ショット
        this.delta += Time.deltaTime;
        if (this.delta > span && shot == 0)
        {
            shot++;
            audi.GetComponent<AudioSourceDirector>().EnemyShot();
            for (int i = 0; i < 7; i++)
            {
                EnemyShoot(i);
            }
        }

        //画面外で消す
        if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }

        //HP管理
        if (HP <= 0)
        {
            audi.GetComponent<AudioSourceDirector>().EnemyKO();
            Destroy(gameObject);
        }
    }

    void EnemyShoot(int n)
    {
        go = Instantiate(RedBulletPrefab);
        var pos = this.gameObject.transform.position;
        var posP = player.transform.position;
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
        posP.y -= 0.28f;

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

        float sin = px / (pxx + pyy);
        float cos = py / (pxx + pyy);

        go.transform.position = new Vector3(pos.x, pos.y, 0);

        go.GetComponent<BulletZikinerauController>().sin = sin;
        go.GetComponent<BulletZikinerauController>().cos = cos;

        switch (n)
        {
            case 1:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 3.0f);
                    break;
                }
            case 2:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -3.0f);
                    break;
                }
            case 3:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 6.0f);
                    break;
                }
            case 4:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -6.0f);
                    break;
                }
            case 5:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 9.0f);
                    break;
                }
            case 6:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -9.0f);
                    break;
                }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            HP -= 1;
        }
        if (collision.gameObject.tag == "Ult")
        {
            HP -= 100;
        }
    }

}
