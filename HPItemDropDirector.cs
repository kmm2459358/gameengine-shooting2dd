using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItemDropDirector : MonoBehaviour
{
    GameObject ItemDrop;
    float Hp;

    void Start()
    {
        this.ItemDrop = GameObject.Find("ItemDirector");
    }

    void Update()
    {
        Hp = GetComponent<EnemySuraimuController>().HP;
        var pos = this.gameObject.transform.position;

        if (Hp <= 0f)
        {
            Debug.Log("HPƒAƒCƒeƒ€");
            this.ItemDrop.GetComponent<ItemDropDirector>().HPItemDrop(pos.x, pos.y);
            Destroy(gameObject);
        }
    }
}
