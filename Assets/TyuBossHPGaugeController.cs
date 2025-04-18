using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TyuBossHPGaugeController : MonoBehaviour
{
    GameObject hpGauge;
    float MaxHp = 1800f;
    public float TyuBossHp;

    void Start()
    {
        TyuBossHp = MaxHp;
        this.hpGauge = GameObject.Find("TyuBossHPGauge");
    }

    void Update()
    {
        //HPQ[Wì
        if (TyuBossHp > 0)
        {
            hpGauge.GetComponent<Image>().fillAmount = TyuBossHp / MaxHp;
        }

        //Q[WðÁ·
        if (TyuBossHp <= 0)
        {
            Destroy(hpGauge);
        }
    }
}
