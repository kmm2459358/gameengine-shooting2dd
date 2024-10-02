using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraimuNoItemDirector : MonoBehaviour
{
    float Hp;
    GameObject audi;

    void Start()
    {
        audi = GameObject.Find("AudioSourceDirector");
    }

    void Update()
    {
        Hp = GetComponent<EnemySuraimuController>().HP;

        if (Hp <= 0f)
        {
            audi.GetComponent<AudioSourceDirector>().EnemyKO();
            Destroy(gameObject);
        }
    }
}
