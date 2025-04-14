using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedSraimuController : MonoBehaviour
{
    //�e�̃v���n�u�I�u�W�F�N�g
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
        //�ړ�
        transform.Translate(-0.038f, 0, 0);

        //��ʊO�ŏ���
        if (transform.position.x > 3.1 || transform.position.x < -3.1)
        {
            Destroy(gameObject);
        }

        //�V���b�g
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            audi.GetComponent<AudioSourceDirector>().EnemyShot();

            EnemyShoot();
        }

        //HP�Ǘ�
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
