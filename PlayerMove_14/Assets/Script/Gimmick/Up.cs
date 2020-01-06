using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    private Vector3 pos;

    public Rigidbody rd;

    public float MoveRange;

    public float Thrust;

    public float StageY_Min;
    public float StageY_Max;

    private bool Hit = false;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hit == true)
        {
            rd.AddForce(0, Thrust, 0, ForceMode.Force);
        }
    }

    // 当たり判定
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Hit = true;
        }
    }
}
