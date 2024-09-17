using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDirector : MonoBehaviour
{
    public GameObject HPItemPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void HPItemDrop(float px, float py)
    {
        Instantiate(HPItemPrefab).transform.position = new Vector3(px, py, 0);
    }
}
