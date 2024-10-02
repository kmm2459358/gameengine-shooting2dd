using UnityEngine;

public class BGMController : MonoBehaviour
{
    AudioSource bgm;
    GameObject gamedirector;
    int wav;
    int i = 0;
    public AudioClip stage;
    public AudioClip boss;
    float delta = 0;

    void Start()
    {
        bgm = GetComponent<AudioSource>();
        this.gamedirector = GameObject.Find("GameDirector");
        bgm.PlayOneShot(stage);
        bgm.loop = true;
    }

    void Update()
    {
        wav = gamedirector.GetComponent<GameDirector>().wave;

        if (wav == 6 && i == 0)
        {
            this.delta += Time.deltaTime;
            if (this.delta > 2.0f)
            {
                bgm.Stop();
                bgm.PlayOneShot(boss);
                i++;
            }
        }
    }
}
