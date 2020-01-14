using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float ReStartPos0X = ReturmGame.PlayerRestartPosition0.x;
    private float ReStartPos0Y = ReturmGame.PlayerRestartPosition0.y;
    private float ReStartPos0Z = ReturmGame.PlayerRestartPosition0.z;

    private float ReStrartPos1X = ReturmGame.PlayerRestartPosition1.x;
    private float ReStrartPos1Y = ReturmGame.PlayerRestartPosition1.y;
    private float ReStrartPos1Z = ReturmGame.PlayerRestartPosition1.z;
   


    public static bool EnemyHit = false;
    public static bool MidPointFlag = false;
    private bool Event1Time = false;
    private bool Event0Time = false;
    public static bool Event1EndFlag = false; //他の所で使っている
    public static bool Event0EndFlag = false; //他の所で使っている


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // イベント1から戻ってきたら
        if (ReturmGame.RestartFlag1 == true)
        {
            Event1Time = true;
        }

        // イベント0から戻ってきたら
        if (ReturmGame.RestartFlag0 == true)
        {
            Event0Time = true;
        }


        if (Event0Time == true)
        {
            //イベント以降前のポジションにワープ
            transform.position = new Vector3(ReStartPos0X, ReStartPos0Y, ReStartPos0Z);
            Event0Time = false;
        }


        if(Event1Time==true)
        {
            //イベント以降前のポジションにワープ
            transform.position = new Vector3(ReStrartPos1X, ReStrartPos1Y, ReStrartPos1Z);
            Event1Time = false;
           
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
        if (collision.gameObject.CompareTag("BridgeStart2")) 
        {
            LongFallingFloor.LongPassFlag = true;
        }
        

    }

    //離れたら
    private void OnTriggerExit(Collider other) 
    {
       
    }
}
