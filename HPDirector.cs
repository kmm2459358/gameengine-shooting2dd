using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDirector : MonoBehaviour
{
    GameObject hpGauge;
    float MaxHp = 10f;
    public float PlayerHp;
    GameObject audi;

    void Start()
    {
        this.hpGauge = GameObject.Find("PlayerHP");
        audi = GameObject.Find("AudioSourceDirector");
    }

    void Update()
    {
        this.hpGauge.GetComponent<Image>().fillAmount = PlayerHp / MaxHp;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HPItem")
        {
            if (PlayerHp < 10)
            {
                Debug.Log("‰ñ•œ");
                audi.GetComponent<AudioSourceDirector>().PlayerHP();
                PlayerHp += 1f;
            }
        }
    }
}
