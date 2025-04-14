using UnityEngine;

public class WarningController : MonoBehaviour
{
    GameObject warning;
    GameObject gamedi;
    GameObject audi;
    int i = 0;
    int j = 0;
    float delta = 0;

    void Start()
    {
        warning = GameObject.Find("Warning");
        gamedi = GameObject.Find("GameDirector");
        audi = GameObject.Find("AudioSourceDirector");
        warning.SetActive(false);
    }

    void Update()
    {
        int wa = gamedi.GetComponent<GameDirector>().wave;
        //Debug.Log(wa);
        if (wa == 6 && i <= 1)
        {
            this.delta += Time.deltaTime;
            if (this.delta > 0.5f)
            {
                warning.SetActive(true);
                if (j == 0)
                {
                    audi.GetComponent<AudioSourceDirector>().Warning();
                    j++;
                }
            }
            if (this.delta > 1.1f)
            {
                warning.SetActive(false);
                i++; delta = 0;
            }
        }
    }
}
