using UnityEngine;
using TMPro;

public class ResultDirector : MonoBehaviour
{
    int count = PlayerController.missCount; 

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Miss count:" + count;
    }
}
