using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2Image : MonoBehaviour
{
    public static bool StopTime2; 

    public float Event2ImageTime = 9.0f; //一枚の表示時間
    public float MaxTime = 9.0f; //上と数字を合わせる(今のところ)

    public float EventDisplayTime = 3; //何秒表示するか

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetImage(); //画像を非表示

        if (StopTime2 == false) //カウントが止まってないなら
        {
            Event2ImageTime -= 1.0f / 60.0f;
        }

        //Event1ImageTimeを減らしていき一定以下になったらSpriteを消す
        if (Event2ImageTime < EventDisplayTime * 2)
        {
            transform.GetChild(0).gameObject.SetActive(false); //Spriteを消す
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (Event2ImageTime < EventDisplayTime)
        {
            StopTime2 = true;
            transform.GetChild(1).gameObject.SetActive(true);
            Event2ImageTime = MaxTime;
        }
    }

    void ResetImage() //画像のリセット
    {
        transform.GetChild(1).gameObject.SetActive(false); //Spriteを消す
    }

}
