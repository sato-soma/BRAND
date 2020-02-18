using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleReset : MonoBehaviour
{
    public bat[] Bats;
    public GameObject[] bats;

    public fallIcicles[] FallIcicles;
    public GameObject[] fallIcicless;

    public float[] time = new float[2];

    public int[] number = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        time[0] = time[1] = 0;

        for (int i = 0; i < number[0]; i++)
        {
            Bats[i] = bats[i].GetComponent<bat>();
        }
        
        for (int j = 0; j < number[1]; j++)
        {
            FallIcicles[j] = fallIcicless[j].GetComponent<fallIcicles>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP.FadeIn == true)
        {
            //コウモリ リスポーン
            for (int i = 0; i < number[0]; i++)
            {
                if (time[0] < 5)
                {
                    time[0] += 1.0f / 60.0f;
                }

                if (time[0] > 5)
                {
                    Bats[i].pos = Bats[i].posSave;
                    Bats[i].bats.SetActive(true);
                    Bats[i].transform.position = Bats[i].pos;
                    time[0] = -1;
                }
                
            }

            //石筍 リスポーン
            for (int j = 0; j < number[1]; j++)
            {

                if (time[1] < 5)
                {
                    time[1] += 1.0f / 60.0f;
                }

                if (time[1] > 5)
                {
                    FallIcicles[j].pos = FallIcicles[j].posSave;
                    FallIcicles[j].hit = false;
                    FallIcicles[j].rigid.isKinematic = false;
                    FallIcicles[j].fallIcicless.SetActive(true);
                    FallIcicles[j].transform.position = FallIcicles[j].pos;
                }

            }
            
        }
        else
        {
            time[0] = time[1] = 0;
        }
    }
}
