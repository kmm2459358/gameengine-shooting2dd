using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverDirector : MonoBehaviour
{
    public GameObject player;
    float hp;
    float delta = 0;
    GameObject[] PlayerBullet;
    GameObject audi;
    int j;

    void Start()
    {
        audi = GameObject.Find("AudioSourceDirector");
        Screen.SetResolution(540, 960, false);
    }

    void Update()
    {
        hp = player.GetComponent<HPDirector>().PlayerHp;
        PlayerBullet = GameObject.FindGameObjectsWithTag("PlayerBullet");

        if (hp <= 0)
        {
            foreach (GameObject bullet in PlayerBullet)
            {
                Destroy(bullet);
            }
            if (j == 0)
            {
                j++;
                audi.GetComponent<AudioSourceDirector>().PlayerDead();
            }
            Application.targetFrameRate = 1;
            Debug.Log("Gameover");
            //Destroy(player);
            this.delta += Time.deltaTime;
            if (this.delta > 1.0f)
                SceneManager.LoadScene("GameoverScene");
        }
    }
}
