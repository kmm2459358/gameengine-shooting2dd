using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCountDirector : MonoBehaviour
{
    public int touchCount = 1;

    void Update()
    {
        //Input.multiTouchEnabled = false;

        if (Input.GetMouseButtonDown(0))
        {
            touchCount++;
            Debug.Log(touchCount);
        }
        if (Input.GetMouseButtonUp(0))
        {
            touchCount--;
            Debug.Log(touchCount);
        }
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Down" + GetComponent<Transform>().name);
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Debug.Log("Up" + GetComponent<Transform>().name);
    //}
}
