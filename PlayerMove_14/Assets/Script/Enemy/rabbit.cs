using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour
{
    public GameObject player;
    public GameObject rabbits;

    private Rigidbody rigid;

    private Vector3 pos;
    private Vector3 posSave;

    public float speed;
    public float dashSpeed;

    public float posFall;

    public float jump;

    public float searchOn;
    public float searchOff;
    public float search;

    public float count;

    public bool searchs;

    public bool hits;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        //現在位置
        pos = rabbits.transform.position;

        //保存
        posSave = rabbits.transform.position;

        count = 0;

        searchs = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);
        
        //視覚範囲入ってない時
        if (search > dis)
        {
            if (pos.y > posFall)
            {
                //hits = false;
                searchs = true;

                if (dis >= searchOff)
                {
                    pos = rabbits.transform.position;
                    pos.x -= speed;
                    rabbits.transform.position = pos;
                }

                //視覚範囲入った時
                if (dis <= searchOn)
                {
                    pos = rabbits.transform.position;
                    pos.x -= dashSpeed;
                    rabbits.transform.position = pos;
                }
            }

        }
        else
        {
            searchs = false;
        }
        
        if(pos.y < posFall)
        {
            rabbits.SetActive(false);
            pos.y = -5;
            //hits = true;
        }

        if (PlayerHP.FadeIn == true)
        {
            rabbits.SetActive(true);
            pos = posSave;
        }

        rabbits.transform.position = pos;


        //if (hits == true)
        //{
        //    if (count < 3f)
        //    {
        //        count += 1.0f / 60.0f;

        //        if (count >= 3f)
        //        {
        //            rabbits.SetActive(true);
        //            pos = posSave;
        //        }
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //3秒ごとに実行される
        if(collision.gameObject.CompareTag("Grand"))
        {
            if(pos.y > posFall)
                Invoke("JumpMethod", 3f);
        }
    }

    private void JumpMethod()
    {
        //ジャンプ
        if(searchs == true)
            rigid.AddForce(rabbits.transform.up * jump);
    }

}
