using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyReset : MonoBehaviour
{
    public boar Boars;
    public GameObject boars;

    public wolf[] Wolfs;
    public GameObject[] wolfs;

    public rabbit[] Rabbits;
    public GameObject[] rabbits;

    public int[] number = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        Boars = boars.GetComponent<boar>();

        for (int i = 0; i < number[0]; i++)
        {
            Wolfs[i] = wolfs[i].GetComponent<wolf>();
        }

        for (int j = 0; j < number[1]; j++)
        {
            Rabbits[j] = rabbits[j].GetComponent<rabbit>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP.FadeIn == true)
        {   
            //イノシシ リスポーン
            Boars.pos = Boars.posSave;
            Boars.boars.SetActive(true);
            Boars.transform.position = Boars.pos;

            //ウサギ リスポーン
            for (int j = 0; j < number[1]; j++)
            {
                Rabbits[j].pos = Rabbits[j].posSave;
                Rabbits[j].rabbits.SetActive(true);
                Rabbits[j].transform.position = Rabbits[j].pos;
            }

            //オオカミ リスポーン
            for (int i = 0; i < number[0]; i++)
            {
                Wolfs[i].pos = Wolfs[i].posSave;
                Wolfs[i].wolfs.SetActive(true);
                Wolfs[i].transform.position = Wolfs[i].pos;
            }
        }
    }
}
