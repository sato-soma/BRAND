using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event0Image : MonoBehaviour
{

    public static bool StopTime0;

    public float Event0ImageTime = 15.0f; //一枚の表示時間
    public float MaxTime = 15.0f; //上と数字を合わせる(今のところ)

    public float EventImage0 = 12; //それぞれ何秒になるまで表示するか(仮)
    public float EventImage1 = 9;
    public float EventImage2 = 6;
    public float EventImage3 = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ResetImage(); //画像を非表示

        if (StopTime0 == false) //カウントが止まってないなら
        {
            Event0ImageTime -= 1.0f / 60.0f;
        }

        //Event1ImageTimeを減らしていき一定以下になったらSpriteを消す
        if (Event0ImageTime < EventImage0)
        {
            transform.GetChild(0).gameObject.SetActive(false); //Spriteを消す
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (Event0ImageTime < EventImage1)
        {
            transform.GetChild(1).gameObject.SetActive(false); //Spriteを消す
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (Event0ImageTime < EventImage2)
        {
            transform.GetChild(2).gameObject.SetActive(false); //Spriteを消す
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (Event0ImageTime < EventImage3)
        {
            StopTime0 = true;
            transform.GetChild(3).gameObject.SetActive(true);
            Event0ImageTime = MaxTime;
        }
    }

    void ResetImage() //画像のリセット
    {
        transform.GetChild(1).gameObject.SetActive(false); //Spriteを消す
        transform.GetChild(2).gameObject.SetActive(false); //Spriteを消す
        transform.GetChild(3).gameObject.SetActive(false); //Spriteを消す
    }
}
