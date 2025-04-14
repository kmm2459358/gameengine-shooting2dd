using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUIDirector : MonoBehaviour
{
    GameObject hpGauge;
    GameObject gamedirector;
    int wav;
    float delta = 0;

    void Start()
    {
        this.hpGauge = GameObject.Find("TyuBossHPGauge");
        this.gamedirector = GameObject.Find("GameDirector");
        hpGauge.SetActive(false);
    }

    void Update()
    {
        wav = gamedirector.GetComponent<GameDirector>().wave;

        //ƒQ[ƒW‚Ì•\Ž¦‰»
        if (wav == 6)
        {
            this.delta += Time.deltaTime;
            if (this.delta > 2.0f)
                hpGauge.SetActive(true);
        }
    }
}
