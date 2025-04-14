using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCountController : MonoBehaviour
{
    GameObject director;
    int waveCount;

    void Start()
    {
        director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        waveCount = director.GetComponent<GameDirector>().wave;
        //Debug.Log(wave);
        string wave = waveCount.ToString();

        gameObject.GetComponent<TextMeshProUGUI>().text = "WAVE " + wave;
    }
}
