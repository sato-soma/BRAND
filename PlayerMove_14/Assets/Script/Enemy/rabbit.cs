using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour
{
    public GameObject player;

    public GameObject rabbits;

    private Rigidbody rigid;

    public Vector3 pos;

    public Vector3 posSave;

    public float speed;
    public float dashSpeed;

    public float posFall;

    public float jump;

    public float searchOn;
    public float searchOff;
    public float search;

    public float count;
    public float dis;

    public bool searchs;

    public bool hits;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        //現在位置
        pos = rabbits.transform.position;

        //保存
        posSave = pos;

        count = 0;

        searchs = false;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(player.transform.position, pos);

        EnemyNomal();
        
        if (pos.y < posFall)
        {
            rabbits.SetActive(false);
            pos = posSave;
        }
        
    }

    private void EnemyNomal()
    {
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
                    pos.x -= speed * Time.deltaTime;
                    rabbits.transform.position = pos;
                }

                //視覚範囲入った時
                if (dis <= searchOn)
                {
                    pos = rabbits.transform.position;
                    pos.x -= dashSpeed * Time.deltaTime;
                    rabbits.transform.position = pos;
                }
                
            }

        }
        else
        {
            searchs = false;
        }
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
