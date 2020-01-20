using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallIcicles : MonoBehaviour
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

        pos = gameObject.transform.position;

        posSave = pos;

        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーと落石の距離の範囲の数値と比較
        dis = Vector3.Distance(player.transform.position, gameObject.transform.position);

        pos = gameObject.transform.position;

        if (hit == false)
        {
            //範囲内に入ったら落下
            if (dis < search)
            {
                hit = true;
                rigid.useGravity = true;
            }
        }

        //落ちてくるつららが指定した数値より下だった場合、元の位置に戻る
        if (pos.y < posFall)
        {
            rigid.isKinematic = true;
            rigid.useGravity = false;
            transform.gameObject.SetActive(false);
            pos = posSave;
        }

        if (PlayerHP.FadeIn == true)
        {
            rigid.isKinematic = false;
            transform.gameObject.SetActive(true);
            hit = false;
        }

        gameObject.transform.position = pos;
    }
}

