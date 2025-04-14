using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject[] Enemy;
    GameObject[] Bullet;
    public GameObject Null;
    public GameObject RedSuraimu;
    public GameObject YellowSuraimu;
    public GameObject YellowSuraimuHP;
    public GameObject YellowSuraimuEnergy;
    public GameObject GreenSuraimu;
    public GameObject BlueSuraimu;
    public GameObject BlueSuraimuHP;
    public GameObject ReBlueSuraimu;
    public GameObject ReBlueSuraimuHP;
    public GameObject ReBlueSuraimuEnergy;
    public GameObject PurpleSuraimu;
    public GameObject TyuBoss;
    float delta = 0;
    float delta1 = 0;
    float delta2 = 0;
    public int wave;
    int i;
    int j;

    void Start()
    {
        Application.targetFrameRate = 60;

        wave = 1;
        i = 1;
        j = 0;

        NullAdd();
    }

    void Update()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Bullet = GameObject.FindGameObjectsWithTag("Bullet");
        switch (wave) {
            case 1:
                {
                    wave = case1(); break;
                }
            case 2:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case2();
                    }
                    break;
                }
            case 3:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case3();
                    }
                    break;
                }
            case 4:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case4();
                    }
                    break;
                }
            case 5:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case5();
                    } 
                    break;
                }
            case 6:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = caseTyuboss();
                    }
                    break;
                }
            case 66:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case6();
                    }
                    break;
                }
            case 7:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case7();
                    }
                    break;
                }
            case 8:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case8();
                    }
                    break;
                }
            case 9:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case9();
                    }
                    break;
                }
            case 10:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = case10();
                    }
                    break;
                }
            case 20:
                {
                    this.delta += Time.deltaTime;
                    if (this.delta > 2.3f)
                    {
                        wave = caseBoss();
                    }
                    break;
                }
        }
    }

    int case1()
    {
        switch (i) 
        {
            case 1:
                {
                    i += GreenSuraimu1(1.5f, 3); break;
                }
            case 2:
                {
                    i += GreenSuraimu1(-1.5f, 3); break;
                }
            case 3:
                {
                    i += GreenSuraimu1(0f, 3); break; 
                }
            case 4:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2.3f)
                    {
                        i += YellowSuraimu1(0f, 7.5f);
                        this.delta1 = 0f;
                    } break;
                }
            case 5:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 1f)
                    {
                        i += GreenSuraimudouji(-1.5f, 0f, 1.5f, 1);
                    } break;
                }
            case 6:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 8f)
                    {
                        YellowSuraimuEnergy1(1.4f, 7.5f);
                        i += YellowSuraimuHP1(-1.4f, 7.5f);
                        NullDestroy();
                    } break;
                }
        }
        if (i >= 7 && Enemy.Length == 0)
        {
            i = 1;
            NullAdd();
            return 2;
        }
        return 1;
    }

    int case2()
    {
        switch (i)
        {
            case 1:
                {
                    i += RedSuraimuMarch(2.62f, 2.8f, 0f, 6); break;
                }
            case 2:
                {
                    i += RedSuraimuMarch(-2.62f, 4.0f, 180f, 6); break;
                }
            case 3:
                {
                    i += YellowSuraimu1(0f, 7.5f); 
                    break;
                }
            case 4:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 4f)
                    {
                        i += BlueSuraimu1(0f, 6.5f, 1f);
                    }
                    break;
                }
            case 5:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(-1.5f, 6.5f, 1f);
                    }
                    break;
                }
            case 6:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(1.5f, 6.5f, -1f);
                    }
                    break;
                }
            case 7:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimuHP1(-0.7f, 6.5f, 1f);
                    }
                    break;
                }
            case 8:
                {
                    i += BlueSuraimuEnergy1(0.7f, 6.5f);
                    NullDestroy(); 
                    break;
                }


        }
        if (i >= 9 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 3;
        }
        return 2;
    }

    int case3()
    {
        switch (i)
        {
            case 1: 
                { 
                    i += RedSuraimuMarch(2.62f, 2.5f, 0f, 3); break;
                }
            case 2:
                {
                    i += RedSuraimuMarch(2.62f, 3.0f, 0f, 3); break;
                }
            case 3:
                {
                    i += RedSuraimuMarch(2.62f, 3.5f, 0f, 3); break;
                }
            case 4:
                {
                    i += RedSuraimuMarch(2.62f, 4.0f, 0f, 3); break;
                }
            case 5:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += RedSuraimuMarch(-2.62f, 2.5f, 180f, 3);
                    }
                    break;
                }
            case 6:
                {
                    i += RedSuraimuMarch(-2.62f, 3.0f, 180f, 3); break;
                }
            case 7:
                {
                    i += RedSuraimuMarch(-2.62f, 3.5f, 180f, 3); break;
                }
            case 8:
                {
                    i += RedSuraimuMarch(-2.62f, 4.0f, 180f, 3); break;
                }
            case 9:
                {
                    i += YellowSuraimu1(0f, 7.5f); break;
                }
            case 10:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 4f)
                    {
                        i += RedSuraimuMarch(-2.62f, 4.2f, 180f, 1);
                    }
                    break;
                }
            case 11:
                {
                    i += RedSuraimuMarch(2.62f, 3.6f, 0f, 1); break;
                }
            case 12:
                {
                    i += RedSuraimuMarch(-2.62f, 3.0f, 180f, 1); break;
                }
            case 13:
                {
                    i += RedSuraimuMarch(2.62f, 2.4f, 0f, 1); break;
                }
            case 14:
                {
                    i += RedSuraimuMarch(-2.62f, 1.8f, 180f, 1); break;
                }
            case 15:
                {
                    i += RedSuraimuMarch(2.62f, 1.2f, 0f, 1); break;
                }
            case 16:
                {
                    i += RedSuraimuMarch(-2.62f, 0.6f, 180f, 1); break;
                }
            case 17:
                {
                    i += RedSuraimuMarch(2.62f, 0.0f, 0f, 1);
                    break;
                }
            case 18:
                {
                    i += YellowSuraimuHP1(0f, 7.5f);
                    NullDestroy(); 
                    break;
                }
        }
        if (i >= 19 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 4;
        }
        return 3;
    }

    int case4()
    {
        switch (i)
        {
            case 1:
                {
                    i += BlueSuraimu1(-1.5f, 6.5f, 1f); break;
                }
            case 2:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(-0.75f, 6.5f, 1f);
                    }
                    break;
                }
            case 3:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(0.0f, 6.5f, 1f);
                    }
                    break;
                }
            case 4:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(0.75f, 6.5f, 1f);
                    }
                    break;
                }
            case 5:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(1.5f, 6.5f, -1f);
                    }
                    break;
                }
            case 6:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(0.75f, 6.5f, -1f);
                    }
                    break;
                }
            case 7:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(0.0f, 6.5f, -1f);
                    }
                    break;
                }
            case 8:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(-0.75f, 6.5f, -1f);
                    }
                    break;
                }
            case 9:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += BlueSuraimu1(-1.5f, 6.5f, -1f);
                    }
                    break;
                }
            case 10:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 4f)
                    {
                        i += BlueSuraimu1(1.5f, 6.0f, -1f);
                        BlueSuraimu1(-1.5f, 6.0f, 1f);
                    }
                    break;
                }
            case 11:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 6f)
                    {
                        i += BlueSuraimuHP1(0.5f, 7.5f, 1f);
                        BlueSuraimuEnergy1(-0.5f, 7.5f);
                        BlueSuraimu1(0f, 6.0f, 1f);
                        NullDestroy();
                    }
                    break;
                }
        }
        if (i >= 12 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 5;
        }
        return 4;
    }

    int case5()
    {
        switch (i)
        {
            case 1:
                {
                    i += GreenSuraimudouji(-1.5f, 0f, 1.5f, 1); break;
                }
            case 2:
                {
                    i += RedSuraimuMarch(-2.62f, 3.0f, 180f, 4); break;
                }
            case 3:
                {
                    i += RedSuraimuMarch(2.62f, 3.8f, 0f, 4); break;
                }
            case 4:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2.5f)
                    {
                        i += PurpleSuraimu1(0f, 7.5f);
                    }
                    break;
                }
            case 5:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += PurpleSuraimu1(1.0f, 8.5f);
                        PurpleSuraimu1(-1.0f, 8.5f);
                    }
                    break;
                }
            case 6:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += PurpleSuraimu1(0f, 8.5f);
                        PurpleSuraimu1(1.5f, 7.5f);
                        PurpleSuraimu1(-1.5f, 7.5f);
                    }
                    break;
                }
            case 7:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2f)
                    {
                        i += PurpleSuraimu1(0f, 8.5f);
                        PurpleSuraimu1(0.8f, 7.5f);
                        PurpleSuraimu1(-0.8f, 7.5f);
                        PurpleSuraimu1(1.6f, 8.5f);
                        PurpleSuraimu1(-1.6f, 8.5f);
                    }
                    break;
                }
            case 8:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2.5f)
                    {
                        i += PurpleSuraimu1(0f, 6.5f);
                        PurpleSuraimu1(0.5f, 7.0f);
                        PurpleSuraimu1(-0.5f, 7.0f);
                        PurpleSuraimu1(1.0f, 7.5f);
                        PurpleSuraimu1(-1.0f, 7.5f);
                        BlueSuraimuHP1(0.4f, 7.5f, 1f);
                        BlueSuraimuHP1(-0.4f, 7.5f, -1f);
                    }
                    break;
                }
            case 9:
                {
                    this.delta1 += Time.deltaTime;
                    if (this.delta1 > 2.0f)
                    {
                        i += PurpleSuraimu1(0.8f, 8.5f);
                        PurpleSuraimu1(1.2f, 6.5f);
                        PurpleSuraimu1(-0.8f, 8.5f);
                        PurpleSuraimu1(-1.2f, 6.5f);
                        PurpleSuraimu1(1.6f, 8.5f);
                        PurpleSuraimu1(-1.6f, 8.5f);
                        NullDestroy();
                    }
                    break;
                }
        }
        if (i >= 10 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 6;
        }
        return 5;
    }

    int caseTyuboss()
    {
        if (i == 1)
        {
            i += TyuBossAdd();
            NullDestroy();
            i++;
        }
        
        if (i >= 2 && Enemy.Length == 0)
        {
            foreach (GameObject bullet in Bullet)
            {
                Destroy(bullet);
            }
            //i = 1;
            this.delta1 += Time.deltaTime;
            if (this.delta1 > 2.0f)
                SceneManager.LoadScene("ClearScene");
            //NullAdd();
            //return 6;
        }
        return 6;
    }

    int case6()
    {
        if (i >= 1 && Enemy.Length == 0)
        {
            i = 1; 
            delta = 0f;
            NullAdd();
            return 7;
        }
        return 6;
    }

    int case7()
    {
        if (i >= 1 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 8;
        }
        return 7;
    }

    int case8()
    {
        if (i >= 1 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 9;
        }
        return 8;
    }

    int case9()
    {
        if (i >= 1 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 10;
        }
        return 9;
    }

    int case10()
    {
        if (i >= 1 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 20;
        }
        return 10;
    }

    int caseBoss()
    {
        if (i >= 1 && Enemy.Length == 0)
        {
            i = 1;
            delta = 0f;
            NullAdd();
            return 21;
        }
        return 20;
    }

    int RedSuraimuMarch(float px, float py, float kakudo ,int kazu)
    {
        float span = 0.22f;
        
        this.delta2 += Time.deltaTime;
        if (this.delta2 > span && j < kazu)
        {
            this.delta2 = 0;
            RedSuraimuAdd(px, py, kakudo);
            j++;
        }
        if (j >= kazu)
        {
            this.delta2 = 0;
            delta1 = 0;
            j = 0;
            return 1;
        }
        else 
        { 
            return 0;
        }
    }

    int YellowSuraimu1(float px, float py)
    {
        YellowSuraimuAdd(px, py);
        return 1;
    }

    int YellowSuraimuHP1(float px, float py)
    {
        YellowSuraimuHPAdd(px, py);
        return 1;
    }

    int YellowSuraimuEnergy1(float px, float py)
    {
        YellowSuraimuEnergyAdd(px, py);
        return 1;
    }

    int GreenSuraimu1(float px, int kazu)
    {
        this.delta2 += Time.deltaTime;
        if (this.delta2 > 1f && j < kazu)
        {
            this.delta2 = 0;
            GreenSuraimuAdd(px, 5.5f);
            j++;
        }
        if (this.delta2 > 1.1f && j == kazu)
        {
            j = 0;
            return 1;
        }
        return 0;
    }

    int GreenSuraimudouji(float px1, float px2, float px3, int kazu)
    {
        float span = 1.5f;

        this.delta2 += Time.deltaTime;
        if (j < kazu && this.delta2 > span)
        {
            this.delta2 = 0;
            GreenSuraimuAdd(px1, 5.5f);
            GreenSuraimuAdd(px2, 5.5f);
            GreenSuraimuAdd(px3, 5.5f);
            j++;
        }
        if (this.delta2 > 1.1f && j == kazu)
        {
            this.delta2 = 0;
            j = 0;
            return 1;
        }
        return 0;
    }

    int BlueSuraimu1(float px, float py, float kakudo)
    {
        BlueSuraimuAdd(px, py, kakudo);
        delta1 = 0;
        return 1;
    }

    int BlueSuraimuHP1(float px, float py, float kakudo)
    {
        BlueSuraimuHPAdd(px, py, kakudo);
        delta1 = 0;
        return 1;
    }

    int BlueSuraimuEnergy1(float px, float py)
    {
        BlueSuraimuEnergyAdd(px, py);
        delta1 = 0;
        return 1;
    }

    int PurpleSuraimu1(float px, float py)
    {
        PurpleSuraimuAdd(px, py);
        delta1 = 0;
        return 1;
    }

    void RedSuraimuAdd(float px, float py, float kakudo)
    {
        GameObject go = Instantiate(RedSuraimu);
        go.transform.rotation = Quaternion.Euler(0.0f, kakudo, 0.0f);
        go.transform.position = new Vector3(px, py, 0);
    }

    void YellowSuraimuAdd(float px, float py)
    {
        GameObject go = Instantiate(YellowSuraimu);
        go.transform.position = new Vector3(px, py, 0);
    }

    void YellowSuraimuHPAdd(float px, float py)
    {
        GameObject go = Instantiate(YellowSuraimuHP);
        go.transform.position = new Vector3(px, py, 0);
    }

    void YellowSuraimuEnergyAdd(float px, float py)
    {
        GameObject go = Instantiate(YellowSuraimuEnergy);
        go.transform.position = new Vector3(px, py, 0);
    }

    void GreenSuraimuAdd(float px, float py)
    {
        GameObject go = Instantiate(GreenSuraimu);
        go.transform.position = new Vector3(px, py, 0);
    }

    void BlueSuraimuAdd(float px, float py, float kakudo)
    {
        if (kakudo > 0)
        {
            GameObject go = Instantiate(BlueSuraimu);
            go.transform.position = new Vector3(px, py, 0);
        }
        else if (kakudo < 0)
        {
            GameObject go = Instantiate(ReBlueSuraimu);
            go.transform.position = new Vector3(px, py, 0);
        }
    }

    void BlueSuraimuHPAdd(float px, float py, float kakudo)
    {
        if (kakudo > 0)
        {
            GameObject go = Instantiate(BlueSuraimuHP);
            go.transform.position = new Vector3(px, py, 0);
        }
        else if (kakudo < 0)
        {
            GameObject go = Instantiate(ReBlueSuraimuHP);
            go.transform.position = new Vector3(px, py, 0);
        }
    }

    void BlueSuraimuEnergyAdd(float px, float py)
    {
        GameObject go = Instantiate(ReBlueSuraimuEnergy);
        go.transform.position = new Vector3(px, py, 0);
    }

    void PurpleSuraimuAdd(float px, float py)
    {
        GameObject go = Instantiate(PurpleSuraimu);
        go.transform.position = new Vector3(px, py, 0);
    }

    void NullAdd()
    {
        GameObject go = Instantiate(Null);
        go.transform.position = new Vector3(0, 0, 0);
    }

    void NullDestroy()
    {
        GameObject go = GameObject.Find("EnemyNullPrefab(Clone)");
        Destroy(go);
    }

    int TyuBossAdd()
    {
        GameObject go = Instantiate(TyuBoss);
        go.transform.position = new Vector3(0, 8.04f, 0);
        return 1;
    }
}
