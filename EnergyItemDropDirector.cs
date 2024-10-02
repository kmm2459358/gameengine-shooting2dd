using UnityEngine;

public class EnergyItemDropDirector : MonoBehaviour
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
            Debug.Log("エネルギーアイテム");
            audi.GetComponent<AudioSourceDirector>().EnemyKO();
            this.ItemDrop.GetComponent<ItemDropDirector>().EnergyItemDrop(pos.x, pos.y);
            Destroy(gameObject);
        }
    }
}
