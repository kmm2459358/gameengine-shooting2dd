using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject PlayerBulletPrefab;
    public GameObject UltPrefab;
    GameObject go;
    float span = 0.05f;
    float delta = 0;
    float MaxEnergy = 4;
    float Energy = 1f;
    GameObject energyGauge;
    int loopCount = 6;
    float flashInterval = 0.1f;
    public static int missCount = 0;
    bool isHit;
    SpriteRenderer sp;
    CircleCollider2D bc2d;
    GameObject UIback;
    GameObject UIframe;
    GameObject audi;
    GameObject touch;
    float pr = 400f;

    void Start()
    {
        this.energyGauge = GameObject.Find("PlayerEnergy");
        //SpriteRenderer�i�[
        sp = GetComponent<SpriteRenderer>();
        //BoxCollider2D�i�[
        bc2d = GetComponent<CircleCollider2D>();
        UIback = GameObject.Find("UIBackground");
        UIframe = GameObject.Find("Frame");
        audi = GameObject.Find("AudioSourceDirector");
        touch = GameObject.Find("TouchCount");
    }

    void Update()
    {
        //�ړ�
        float keyX = 0f;
        float keyY = 0f;
        float srrow = 1.0f;
        if (this.transform.position.x < 2.1954f)
            if (Input.GetKey(KeyCode.RightArrow)) keyX = 0.06f;
        if (this.transform.position.x > -2.1954f)
            if (Input.GetKey(KeyCode.LeftArrow)) keyX = -0.06f;
        if (this.transform.position.y < 4.6664f)
            if (Input.GetKey(KeyCode.UpArrow)) keyY = 0.06f;
        if (this.transform.position.y > -3f)
            if (Input.GetKey(KeyCode.DownArrow)) keyY = -0.06f;

        if (Input.GetKey(KeyCode.LeftShift)) srrow = 2.5f;

        transform.Translate(keyX / srrow, keyY / srrow, 0);

        //�V���b�g
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            switch (Energy)
            {
                case 4:
                    {
                        PlayerShoot2();
                        for (int i = 0; i < 2; i++)
                        {
                            PlayerShoot1(i);
                            PlayerShoot0(i);
                        }
                        break;
                    }
                case 3:
                case 2:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            PlayerShoot1(i);
                            PlayerShoot0(i);
                        }
                        break;
                    }
                case 1:
                case 0:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            PlayerShoot0(i); 
                        }
                        break;
                    }
            }
            
        }

        //����UI�Ԃ�
        if(GetComponent<HPDirector>().PlayerHp <= 0)
        {
            UIback.GetComponent<Image>().color = new Color(0.475f, 0.008677468f, 0.008677468f);
            UIframe.GetComponent<Image>().color = Color.red;
        }

        //�G�l���M�[�Q�[�W�Ǘ�
        if(Energy < 0)
        {
            Energy = 0;
        }
        this.energyGauge.GetComponent<Image>().fillAmount = Energy / MaxEnergy;

        //�K�E�Z
        if (Input.GetMouseButtonDown(0))
        {
            pr = Input.mousePosition.y;
            //Debug.Log(pr);
        }
        if (Input.GetKeyDown(KeyCode.X) || touch.GetComponent<TouchCountDirector>().touchCount == 2 || pr <= 385f)
        {
            pr = 400f;
            if (Energy > 0)
            {
                for (int i = 0; i < 3; i++)
                    UltShot(i);
            }
        }
    }

    void PlayerShoot0(int n)
    {
        go = Instantiate(PlayerBulletPrefab);
        var pos = this.gameObject.transform.position;

        if (pos.x > 2.1954f) 
        {
            pos.x = 2.1954f;
        }
        if (pos.x < -2.1954f)
        {
            pos.x = -2.1954f;
        }
        if (pos.y > 4.6664f)
        {
            pos.y = 4.6664f;
        }
        if (pos.y < -3f)
        {
            pos.y = -3f;
        }

        switch (n)
        {
            case 0:
                {
                    go.transform.position = new Vector3(pos.x + 0.18f, pos.y + 0.297f, 0f);
                    break;
                }
            case 1:
                {
                    go.transform.position = new Vector3(pos.x - 0.18f, pos.y + 0.297f, 0);
                    break;
                }
        }
    }

    void PlayerShoot1(int n)
    {
        go = Instantiate(PlayerBulletPrefab);
        var pos = this.gameObject.transform.position;

        if (pos.x > 2.1954f)
        {
            pos.x = 2.1954f;
        }
        if (pos.x < -2.1954f)
        {
            pos.x = -2.1954f;
        }
        if (pos.y > 4.6664f)
        {
            pos.y = 4.6664f;
        }
        if (pos.y < -3f)
        {
            pos.y = -3f;
        }

        switch (n)
        {
            case 0:
                {
                    go.transform.position = new Vector3(pos.x + 0.334f, pos.y, 0f);
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -7.0f);
                    break;
                }
            case 1:
                {
                    go.transform.position = new Vector3(pos.x - 0.334f, pos.y, 0);
                    go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 7.0f);
                    break;
                }
        }
    }

    void PlayerShoot2()
    {
        go = Instantiate(PlayerBulletPrefab);
        var pos = this.gameObject.transform.position;

        if (pos.x > 2.1954f)
        {
            pos.x = 2.1954f;
        }
        if (pos.x < -2.1954f)
        {
            pos.x = -2.1954f;
        }
        if (pos.y > 4.6664f)
        {
            pos.y = 4.6664f;
        }
        if (pos.y < -3f)
        {
            pos.y = -3f;
        }
        go.transform.position = new Vector3(pos.x, pos.y + 0.6f, 0f);
    }

    void UltShot(int n)
    {
        go = Instantiate(UltPrefab);
        var pos = this.gameObject.transform.position;
        go.transform.position = new Vector3(pos.x, pos.y, 0f);
        switch (n)
        {
            case 1:
                go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 30.0f);
                break;
            case 2:
                go.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -30.0f);
                Energy -= 1f;
                break;
        }
        audi.GetComponent<AudioSourceDirector>().PlayerUlt();
    }

    //�����蔻��
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy")
        {
            Debug.Log("��e");
            if (isHit == false)
            {
                GetComponent<HPDirector>().PlayerHp -= 1f;
                audi.GetComponent<AudioSourceDirector>().PlayerHit();
                StartCoroutine(_hit());
                missCount++;
            }
        }

        if (collision.gameObject.tag == "EnergyItem")
        {
            if (Energy < 4)
            {
                Debug.Log("�G�l���M�[�[�d");
                audi.GetComponent<AudioSourceDirector>().PlayerHP();
                Energy += 1f;
            }
        }
    }

    //�_�ł����鏈��
    IEnumerator _hit()
    {
        //������t���O��true�ɕύX�i�������Ă����ԁj
        isHit = true;

        UIback.GetComponent<Image>().color = new Color(0.475f, 0.008677468f, 0.008677468f);
        UIframe.GetComponent<Image>().color = Color.red;

        //�_�Ń��[�v�J�n
        for (int i = 0; i < loopCount; i++)
        {
            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I�t
            sp.enabled = false;

            UIback.GetComponent<Image>().color = new Color(0.008677468f, 0.008677468f, 0.1415094f);
            UIframe.GetComponent<Image>().color = Color.blue;

            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I��
            sp.enabled = true;
        }

        //�_�Ń��[�v���������瓖����t���O��false(�������ĂȂ����)
        isHit = false;
    }
}
