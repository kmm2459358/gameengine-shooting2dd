using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreenSuraimuController : MonoBehaviour
{
    //弾のプレハブオブジェクト
    public GameObject PurpleBulletPrefab;
    GameObject go;
    float span = 1.9f;
    float delta = 0;
    int HP = 45;
    float kakudo;
    GameObject audi;

    void Start()
    {
        kakudo = Random.Range(0, 301) / 10;

        audi = GameObject.Find("AudioSourceDirector");
    }

    void Update()
    {
        //移動
        transform.Translate(0f, -0.015f, 0);

        //画面外で消す
        if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }

        //ショット
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            audi.GetComponent<AudioSourceDirector>().EnemyShot();
            for (int i = 0; i < 12; i++)
            {
                EnemyShoot(i);
            }
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
        go = Instantiate(PurpleBulletPrefab);
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
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 30.0f);
                    break;
                }
            case 2:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 60.0f);
                    break;
                }
            case 3:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 90.0f);
                    break;
                }
            case 4:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 120.0f);
                    break;
                }
            case 5:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 150.0f);
                    break;
                }
            case 6:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 180.0f);
                    break;
                }
            case 7:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 210.0f);
                    break;
                }
            case 8:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 240.0f);
                    break;
                }
            case 9:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 270.0f);
                    break;
                }
            case 10:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 300.0f);
                    break;
                }
            case 11:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, kakudo + 330.0f);
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
