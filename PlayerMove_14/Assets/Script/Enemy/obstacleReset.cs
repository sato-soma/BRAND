using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleReset : MonoBehaviour
{
    public bat[] Bats;
    public GameObject[] bats;

    public fallIcicles[] FallIcicles;
    public GameObject[] fallIcicless;
    

    public int[] number = new int[2];

    // Start is called before the first frame update
    void Start()
    {
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
                Bats[i].pos = Bats[i].posSave;
                Bats[i].bats.SetActive(true);
                Bats[i].transform.position = Bats[i].pos;
            }

            //石筍 リスポーン
            for (int j = 0; j < number[1]; j++)
            {
                FallIcicles[j].pos = FallIcicles[j].posSave;
                FallIcicles[j].hit = false;
                FallIcicles[j].rigid.isKinematic = false;
                FallIcicles[j].fallIcicless.SetActive(true);
                FallIcicles[j].transform.position = FallIcicles[j].pos;
            }
            
        }
    }
}
