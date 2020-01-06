using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Vector3 pos;

    public float MoveRange;

    public float UpTime;


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(UpTime==0)
        {
            UpTime = 1;
        }

        gameObject.transform.position = new Vector3(pos.x, pos.y + Mathf.PingPong(Time.time * UpTime, MoveRange), pos.z);
    }
}
