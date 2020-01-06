using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    public float FallingSpeed = 2.0f;

    public float FallingEndPosition = -2.0f;

    private Vector3[] GetChildPosition = new Vector3[18];
    private Vector3[] GetStartPos = new Vector3[18];

    public static bool PassFlag = false; //橋を通ったか

    private int Count = 0; //橋の枚数カウント

    private int i = 0;
    private int value = 18;
    private int maxValue = 17;

    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < value; j++)
        {
            GetChildPosition[j] = transform.GetChild(j).gameObject.transform.position;
            GetStartPos[j] = transform.GetChild(j).gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // transform.GetChild(5).gameObject.SetActive(false); //Spriteを消す

        //Debug.Log(transform.GetChild(5).gameObject.transform.position);

        //// 死んだら
        if (PlayerHP.FadeIn == true)
        {
            // 位置更新
            for (i = 0; i < value; i++)
            {
                GetChildPosition[i] = GetStartPos[i];
                transform.GetChild(i).gameObject.SetActive(true);
            }
            Count = 0;
            PassFlag = false;
        }
        
        // 橋を渡る時
        if (PassFlag == true)
        {
            // とりあえず落とす 
            GetChildPosition[Count].y -= FallingSpeed * Time.deltaTime;
            
            if (GetChildPosition[Count].y < FallingEndPosition)
            {
                transform.GetChild(Count).gameObject.SetActive(false);
                Count++;
            }
        }

        if (Count > maxValue)
        {
            PassFlag = false;
            Count = 0;
        }

        // 位置更新

        for (int j = 0; j < value; j++)
        {
            transform.GetChild(j).gameObject.transform.position = GetChildPosition[j];
        }
        
        Debug.Log(transform.GetChild(6));
        //Debug.Log(transform.GetChild(7));
        Debug.Log(PassFlag);
    }
}
