using UnityEngine;

public class UltBulletController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0.28f, 0);

        //��ʊO�ŏ���
        if (this.transform.position.y > 6f ||
            this.transform.position.x < -4f ||
            this.transform.position.x > 4f)
        {
            Destroy(gameObject);
        }
    }
}
