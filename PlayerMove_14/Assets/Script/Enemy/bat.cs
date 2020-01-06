using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public GameObject player;

    private Rigidbody rigid;

    private Vector3 pos;

    private Vector3 vector;

    public float speed;
    public float posY;

    //視覚範囲距離の数値
    public float search;

    public float[] time = new float[2];

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        pos = transform.position;

        time[0] = 0;
        time[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);

        if (dis < 30)
        {
            if (time[0] >= 0)
            {
                time[1] = -1;
                time[0] += 1.0f / 60f;
                pos = transform.position;
                pos.x -= speed;
                pos.y = posY + Mathf.PingPong(time[0], 1f);
                transform.position = pos;
            }

            if (time[0] >= 4)
            {
                time[0] = -1;
                time[1] = 0;
            }

            if (time[1] >= 0)
            {
                time[0] = -1;
                time[1] += 1.0f / 60f;
                pos = transform.position;
                pos.x -= speed;
                transform.position = pos;
            }

            if (time[1] >= 5)
            {
                time[1] = -1;
                time[0] = 0;
            }
            //rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));
        }
        
    }
    
}
