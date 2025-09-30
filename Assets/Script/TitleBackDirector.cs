using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBackDirector : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(540, 960, false);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
