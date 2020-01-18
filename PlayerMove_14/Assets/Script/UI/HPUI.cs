using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{

    public GameObject Player;
    public GameObject StartPoint; //スタート位置
    public GameObject MidPoint; //中間スタート位置
    public GameObject HP;

    public Vector3 Pos;
    private Vector3 HpUiPosition;
    public static Vector3 HpUiPositionOld;

    public static int HitCount;
    public int HitCuntMax = 2;


    public static bool HitPoint0 = false;

    // Start is called before the first frame update
    void Start()
    {
        // HitCount = HitCuntMax;

        //HpUiPosition.x = 4.5f; //とりあえずいい感じの位置
        //HpUiPosition.y = 2.0f; //

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(HitCount);

        //LifeCount();

        //Pos.x = Player.transform.position.x;
        //Pos.y = Player.transform.position.y;

        //if (ReturmGame.RestartFlag1 == false) //イベント中じゃなかったら
        //{
        //    transform.position = HpUiPosition + Pos;
        //    //transform.position = Pos;
        //    HpUiPositionOld = transform.position;
        //}
        //else
        //{
        //   // HpUiPositionOld = new Vector3(ReturmGame.HpUiRestartPosition.x, ReturmGame.HpUiRestartPosition.y, 0.0f);
        //    transform.position = new Vector3(HpUiPositionOld.x, HpUiPositionOld.y, 0.0f);
        //   // HitCount = ReturmGame.HpResutartCount;
        //    transform.GetChild(HitCount).gameObject.SetActive(false);
        //}


        //if (HitPoint0 == true || PlayerDeath.DeathFlag == true)
        //{
        //    Pos.x = HpUiPosition.x + Player.transform.position.x;
        //    Pos.y = HpUiPosition.y + Player.transform.position.y;

        //    if (PlayerState.MidPointFlag == true)
        //    {
        //        transform.position = HpUiPosition + Pos + MidPoint.transform.position;
        //    }
        //    else
        //    {
        //        transform.position = HpUiPosition + Pos + StartPoint.transform.position;
        //    }

        //    HitCount = HitCuntMax;

        //    transform.GetChild(HitCuntMax - 1).gameObject.SetActive(true);

        //    HitPoint0 = false;

        //}
    }

    private void LifeCount()
    {

        //if (PlayerState.EnemyHit == true) //敵と当たったら
        //{
        //    HitCount -= 1;

        //    transform.GetChild(HitCount).gameObject.SetActive(false); //Spriteを消す

        //    PlayerState.EnemyHit = false;
        //}

        //if (HitCount == 0) //HPが0になったら
        //{
        //    HitPoint0 = true;
        //    PlayerDeath.DeathFlag = true;
        //}
    }

}
