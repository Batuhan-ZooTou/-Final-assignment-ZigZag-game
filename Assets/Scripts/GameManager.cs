using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Transform PlatformSp;
    public GameObject platform;
    public GameObject CurrentPlatform;
    public TextMeshProUGUI Score;
    public Player player;
    public GameObject pill;
    public GameObject endPanel;
    int count;
    float a;
    void Start()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.25f);
    }

    void Update()
    {
        if (!player.isDead)
        {
            a += Time.deltaTime * player.speed;
            int score = Mathf.FloorToInt(a);
            Score.text = "" + score;
        }
        else
        {
            endPanel.SetActive(true);
        }

    }
    public void SpawnPlatform()
    {
        count++;
        float chance=0.5f;
        CurrentPlatform = Instantiate(platform, new Vector3(PlatformSp.position.x, PlatformSp.position.y, PlatformSp.position.z), Quaternion.identity);
        float rnd = Random.Range(0, 1.1f);
        //Debug.Log(rnd);
        if (rnd>=chance)
        {
            chance = 0.75f;
            PlatformSp.transform.position = new Vector3(PlatformSp.transform.position.x-1, -5.919983f, PlatformSp.transform.position.z);
            if (count%40==0)
            {
                Instantiate(pill, new Vector3(PlatformSp.position.x, -2.919983f, PlatformSp.position.z), Quaternion.identity);
            }
        }
        else
        {
            chance = 0.35f;
            PlatformSp.transform.position = new Vector3(PlatformSp.transform.position.x, -5.919983f, PlatformSp.transform.position.z-1);
            if (count % 40 == 0)
            {
                Instantiate(pill, new Vector3(PlatformSp.position.x, -2.919983f, PlatformSp.position.z),Quaternion.identity);
            }
        }
    }
}
