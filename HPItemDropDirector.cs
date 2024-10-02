using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItemDropDirector : MonoBehaviour
{
    GameObject ItemDrop;
    float Hp;
    GameObject audi;

    void Start()
    {
        this.ItemDrop = GameObject.Find("ItemDirector");
        audi = GameObject.Find("AudioSourceDirector");
    }

    void Update()
    {
        Hp = GetComponent<EnemySuraimuController>().HP;
        var pos = this.gameObject.transform.position;

        if (Hp <= 0f)
        {
            Debug.Log("HPƒAƒCƒeƒ€");
            audi.GetComponent<AudioSourceDirector>().EnemyKO();
            this.ItemDrop.GetComponent<ItemDropDirector>().HPItemDrop(pos.x, pos.y);
            Destroy(gameObject);
        }
    }
}
