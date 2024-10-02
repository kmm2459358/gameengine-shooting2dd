using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuraimuController : MonoBehaviour
{
    //プレイヤーオブジェクト
    GameObject player;
    //弾のプレハブオブジェクト
    public GameObject RedBulletPrefab;
    GameObject go;
    int j = 0;
    float teisi = 0;
    float speed = -0.08f;
    float span = 0.4f;
    float delta = 0;
    float px = 0.0f;
    float py = -1.0f;
    public int HP = 90;
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
        if (this.teisi > 4f && j == 1)
        {
            speed -= 0.002f;
            if (this.teisi > 6.5f && j == 1)
            {
                j++;
                teisi = 0;
            }
        }

        //ショット
        this.delta += Time.deltaTime;
        if (this.delta > span && teisi < 4f){
            this.delta = 0;
            audi.GetComponent<AudioSourceDirector>().EnemyShot();
            for (int i = 0; i < 3; i++)
            {
                EnemyShoot(i);
            }
        }

        //画面外で消す
        if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }
    }

    void EnemyShoot(int n)
    {
        go = Instantiate(RedBulletPrefab);
        var pos = this.gameObject.transform.position;
        var posP = player.transform.position;
        posP.y -= 0.28f;
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

        go.GetComponent<BulletZikinerauController>().sin = sin;
        go.GetComponent<BulletZikinerauController>().cos = cos;

        switch (n)
        {
            case 1:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 15.0f);
                    break;
                }
            case 2:
                {
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -15.0f);
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