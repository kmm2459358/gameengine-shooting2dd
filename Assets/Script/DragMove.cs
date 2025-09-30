using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    /*[SerializeField] private float slideSpeed = 2f; //横移動のスピード。Inspector等で設定
    [SerializeField] float speed;
    private Vector3 screenPoint;
    private Vector3 offset;

    private void Update()
    {
        PlayerInput();

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector2(
            //エリア指定して移動する
            Mathf.Clamp(transform.position.x + moveX, -2.1954f, 2.1954f),
            Mathf.Clamp(transform.position.y + moveY, -3.0f, 4.6664f)
            );
    }

    private void PlayerInput()
    {
        //もし入力がなかったらreturnする
        if (Input.touchCount <= 0) return;

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchPosition.x * slideSpeed * Time.deltaTime, 0, 0);
        }
    }

    //オブジェクトをクリックしてドラッグ状態にある間呼び出される関数（Unityのマウスイベント）
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    // 追加
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }*/

    const float LOAD_WIDTH = 5.4f;
    const float LOAD_HEIGHT = 9.6f;
    const float MOVE_MAXx = 2.4f;
    const float MOVE_MAXy = 4.5f;
    Vector3 previousPos, currentPos;

    void Update()
    {
        // スワイプによる移動処理
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            // スワイプによる移動距離を取得
            currentPos = Input.mousePosition;
            float diffDistanceX = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;
            float diffDistanceY = (currentPos.y - previousPos.y) / Screen.height * LOAD_HEIGHT;

            // 次のローカルx座標を設定 ※道の外にでないように
            float newX = Mathf.Clamp(transform.localPosition.x + diffDistanceX, -MOVE_MAXx, MOVE_MAXx);
            float newY = Mathf.Clamp(transform.localPosition.y + diffDistanceY, -MOVE_MAXy + 2, MOVE_MAXy);
            transform.localPosition = new Vector3(newX, newY, 0);

            // タップ位置を更新
            previousPos = currentPos;
        }
    }
}