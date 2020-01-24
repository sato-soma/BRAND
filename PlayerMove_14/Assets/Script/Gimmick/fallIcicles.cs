using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallIcicles : MonoBehaviour
{
    public Rigidbody rigid;

    //プレイヤー
    public GameObject player;

    //石筍（つらら石）
    public GameObject fallIcicless;

    public Vector3 pos;

    //石筍の位置保存
    public Vector3 posSave;
    
    //プレイヤーとの距離
    public float dis;

    //範囲の数値
    public float search;

    public float posFall;

    //プレイヤーに当たった時の判定
    public bool hit;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pos = fallIcicless.transform.position;

        posSave = pos;

        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーと石筍の距離数値
        dis = Vector3.Distance(player.transform.position, fallIcicless.transform.position);

        pos = fallIcicless.transform.position;

        if (hit == false)
        {
            //範囲内に入ったら落下
            if (dis < search)
            {
                hit = true;
                rigid.useGravity = true;
            }
        }

        //落ちてくる石筍が指定した数値より下だった場合、元の位置に戻る
        if (pos.y < posFall)
        {
            rigid.isKinematic = true;
            rigid.useGravity = false;
            fallIcicless.SetActive(false);
            pos = posSave;
        }
        
        fallIcicless.transform.position = pos;
    }
}

