using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static bool EnemyHit = false;
    public static bool MidPointFlag = false; //中間ポイントを通ったか

    public static bool[] EventEndFlag = new bool[4]; //他の所で使っている: イベントが見終わっているか

    public GameObject[] EventPosition = new GameObject[4]; //イベント見た後の復帰地点


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ステージ1の一つ目のイベントから戻ってきたら
        if (ReturmGame.RestartFlag[0] == true)
        {
            //イベント以降前のポジションにワープ
            transform.position = EventPosition[0].transform.position;
        }

        // ステージ1の2つ目のイベントから戻ってきたら
        if (ReturmGame.RestartFlag[1] == true)
        {
            //イベント以降前のポジションにワープ
            transform.position = EventPosition[1].transform.position;
        }

        // ステージ2の1つ目のイベントから戻ってきたら
        if (ReturmGame.RestartFlag[2] == true)
        {
            //イベント以降前のポジションにワープ
            transform.position = EventPosition[2].transform.position;
        }

        // ステージ2の2つ目のイベントから戻ってきたら
        if (ReturmGame.RestartFlag[3] == true)
        {
            //イベント以降前のポジションにワープ
            transform.position = EventPosition[3].transform.position;
        }
    }

    //当たったら
    private void OnCollisionEnter(Collision collision)
    {
        //敵と当たったら
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (EnemyHit == false)
            {
                EnemyHit = true;
            }
        }
        
        //障害物と当たったら
        if (collision.gameObject.CompareTag("Blow"))
        {
            PlayerDeath.DeathFlag = true;
        }

    }

    //敵と離れたら
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHit = false;
        }

    }
    

    //当たったら
    private void OnTriggerEnter(Collider collision)
    {
        //中間ポイントにきたら
        if (collision.gameObject.CompareTag("MidPoint"))
        {
            MidPointFlag = true;
        }

        //一つ目の橋にきたら
        if (collision.gameObject.CompareTag("BridgeStart"))
        {
            FallingFloor.PassFlag = true;
        }

        //二つ目の橋にきたら
        //if (collision.gameObject.CompareTag("BridgeStart2")) 
        //{
        //    LongFallingFloor.LongPassFlag = true;
        //}
    }

    //離れたら
    private void OnTriggerExit(Collider other)
    {

    }
}
