using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueReSuraimuController : MonoBehaviour
{
    //弾のプレハブオブジェクト
    public GameObject GreenBulletPrefab;
    GameObject go;
    int j = 0;
    float teisi = 0;
    float speed = -0.08f;
    float span = 0.11f;
    float delta = 0;
    int HP = 80;
    float kakudo = 0;
    GameObject audi;

    void Start()
    {
        teisi = 0;

        audi = GameObject.Find("AudioSourceDirector");
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
        if (this.teisi > 6f && j == 1)
        {
            speed -= 0.002f;
            if (this.teisi > 6.5f && j == 1)
            {
                j++;
            }
        }

        //ショット
        if (this.teisi < 6f)
        {
            this.delta += Time.deltaTime;
            if (this.delta > span)
            {
                this.delta = 0;
                audi.GetComponent<AudioSourceDirector>().EnemyShot();
                for (int i = 0; i < 4; i++)
                {
                    EnemyShoot(i, kakudo);
                }
                kakudo -= 10f;
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

    void EnemyShoot(int n, float kakudo)
    {
        go = Instantiate(GreenBulletPrefab);
        var pos = this.gameObject.transform.position;

        go.transform.position = new Vector3(pos.x, pos.y, 0);

        switch (n)
        {
            case 0:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo);
                    break;
                }
            case 1:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f + kakudo);
                    break;
                }
            case 2:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f + kakudo);
                    break;
                }
            case 3:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f + kakudo);
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