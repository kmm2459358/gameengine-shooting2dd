using UnityEngine;
using TMPro;

public class ResultDirector : MonoBehaviour
{
    int count = PlayerController.missCount; 
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Miss count:" + count;
    }
}
