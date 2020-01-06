using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongFallingFloor : MonoBehaviour
{
    public float FallingSpeed = 2.0f;

    public float FallingEndPosition = -2.0f;

    private Vector3[] GetChildPosition = new Vector3[18];

    private Vector3[] GetStartPos = new Vector3[18];

    public static bool LongPassFlag = false; //橋を通ったか

    private int Count = 0; //橋の枚数カウント

    private int i = 0;

    private int Value = 18;
    private int MaxValue = 17;

    void Start()
    {
        // 橋板が順番ではないため

        for(int j=0; j < Value; j++)
        {
            GetChildPosition[j] = transform.GetChild(j).gameObject.transform.position;
            GetStartPos[j] = transform.GetChild(j).gameObject.transform.position;
        }
       
       
       
    }

    void Update()
    {
        // transform.GetChild(5).gameObject.SetActive(false); //Spriteを消す

        Debug.Log(transform.GetChild(5).gameObject.transform.position);

        // 死んだら
        if (PlayerHP.FadeIn == true)
        {
            // 位置更新
            for (i = 0; i < Value; i++)
            {
                GetChildPosition[i] = GetStartPos[i];
                transform.GetChild(i).gameObject.SetActive(true);
            }
            Count = 0;
            LongPassFlag = false;
        }

        // 橋を渡る時
        if (LongPassFlag == true)
        {

            // とりあえず落とす
            GetChildPosition[Count].y -= FallingSpeed * Time.deltaTime;

            // 板のじゅんばんが無茶苦茶なので消すは…
            if (GetChildPosition[Count].y < FallingEndPosition)
            {
                transform.GetChild(Count).gameObject.SetActive(false);
                Count += 1;
            }

            if (Count > MaxValue)
            {
                LongPassFlag = false;
                Count = 0;
            }


        }

        // 位置更新
        for(int j = 0; j < Value; j++)
        {
            transform.GetChild(j).gameObject.transform.position = GetChildPosition[j];

        }

       
      
    }
}
