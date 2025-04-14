using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTyuBossController : MonoBehaviour
{
    //プレイヤーオブジェクト
    GameObject player;
    //弾のプレハブオブジェクト
    public GameObject BigBulletPrefab;
    GameObject go;
    GameObject ItemDrop;
    int j = 0;
    float teisi = 0;
    float speed = -0.1f;
    float span = 2.5f;
    float delta = 0;
    float px = 0.0f;
    float py = -1.0f;
    GameObject audi;

    void Start()
    {
        player = GameObject.Find("Player");
        audi = GameObject.Find("AudioSourceDirector");

        this.ItemDrop = GameObject.Find("ItemDirector");

        teisi = 0;
    }

    void Update()
    {
        var pos = this.gameObject.transform.position;

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

        //ショット
        this.delta += Time.deltaTime;
        if (this.delta > span && speed < 1f)
        {
            this.delta = 0;
            audi.GetComponent<AudioSourceDirector>().EnemyShot();
            for (int i = 0; i < 4; i++)
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
        if (GetComponent<TyuBossHPGaugeController>().TyuBossHp <= 0f)
        {
            this.ItemDrop.GetComponent<ItemDropDirector>().HPItemDrop(pos.x - 0.5f, pos.y);
            this.ItemDrop.GetComponent<ItemDropDirector>().HPItemDrop(pos.x + 0.5f, pos.y);
            Destroy(gameObject);
        }
    }

    void EnemyShoot(int n)
    {
        go = Instantiate(BigBulletPrefab);
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

        float sin = px / (pxx + pyy);
        float cos = py / (pxx + pyy);
        //Debug.Log("px" + px);
        //Debug.Log("py" + py);

        go.transform.position = new Vector3(pos.x, pos.y, 0);

        go.GetComponent<BulletTyuBossBigController>().sin = sin;
        go.GetComponent<BulletTyuBossBigController>().cos = cos;

        switch (n)
        {
            case 1:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                    break;
                }
            case 2:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                    break;
                }
            case 3:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
                    break;
                }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GetComponent<TyuBossHPGaugeController>().TyuBossHp -= 1f;
        }
        if (collision.gameObject.tag == "Ult")
        {
            GetComponent<TyuBossHPGaugeController>().TyuBossHp -= 20;
        }
    }

}
