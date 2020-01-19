using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follRock : MonoBehaviour
{
    private Rigidbody rigid;

    //プレイヤー
    public GameObject player;

    //落石
    private Vector3 pos;

    private Vector3 posSave;

    public float dis;
    public float search;
    public bool hit;
    public float posFall;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pos = transform.position;

        posSave = pos;

        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーと落石の距離が視覚範囲の数値と比較
        dis = Vector3.Distance(player.transform.position, transform.position);

        pos = transform.position;

        if (hit == false)
        {
            //範囲外に出たら落下
            if (dis < search)
            {
                rigid.useGravity = false;
            }
            else
            {
                hit = true;
                rigid.useGravity = true;
            }
        }

        //転がる岩が指定した数値より下だった場合、元の位置に戻る
        if(pos.y < posFall)
        {
            rigid.useGravity = false;
            hit = false;
            pos = posSave;
        }

        transform.position = pos;
    }
}
