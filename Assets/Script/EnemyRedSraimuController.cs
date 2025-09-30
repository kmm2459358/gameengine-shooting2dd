using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedSraimuController : MonoBehaviour
{
    //弾のプレハブオブジェクト
    public GameObject GravityBulletPrefab;
    GameObject go;
    float span = 0.3f;
    float delta = 0;
    public int HP = 7;
    GameObject audi;

    void Start()
    {
        audi = GameObject.Find("AudioSourceDirector");
    }

    void Update()
    {
        //移動
        transform.Translate(-0.038f, 0, 0);

        //画面外で消す
        if (transform.position.x > 3.1 || transform.position.x < -3.1)
        {
            Destroy(gameObject);
        }

        //ショット
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            audi.GetComponent<AudioSourceDirector>().EnemyShot();

            EnemyShoot();
        }

        //HP管理
        if (HP <= 0)
        {
            audi.GetComponent<AudioSourceDirector>().EnemyKO();
            Destroy(gameObject);
        }
    }

    void EnemyShoot()
    {
        var pos = this.gameObject.transform.position;

        go = Instantiate(GravityBulletPrefab);

        go.transform.position = new Vector3(pos.x, pos.y, 0);
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
