using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    [SerializeField] private float slideSpeed = 2f; //���ړ��̃X�s�[�h�BInspector���Őݒ�
    [SerializeField] float speed;
    private Vector3 screenPoint;
    private Vector3 offset;

    private void Update()
    {
        PlayerInput();

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector2(
            //�G���A�w�肵�Ĉړ�����
            Mathf.Clamp(transform.position.x + moveX, -2.1954f, 2.1954f),
            Mathf.Clamp(transform.position.y + moveY, -3.0f, 4.6664f)
            );
    }

    private void PlayerInput()
    {
        //�������͂��Ȃ�������return����
        if (Input.touchCount <= 0) return;

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchPosition.x * slideSpeed * Time.deltaTime, 0, 0);
        }
    }

    //�I�u�W�F�N�g���N���b�N���ăh���b�O��Ԃɂ���ԌĂяo�����֐��iUnity�̃}�E�X�C�x���g�j
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    // �ǉ�
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
}
