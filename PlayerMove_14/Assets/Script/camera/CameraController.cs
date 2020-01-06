using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player; //プレイヤーオブジェクトの参照用
    private Vector3 offset; //プレイヤーとカメラ間のオフセット距離

    public float CameraMoveRangeY_Max;
    public float CameraMoveRangeY_Min;

    public float CameraMoveRangeX_Max;
    public float CameraMoveRangeX_Min;

    private bool CameraFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し格納
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.transform.position.x == Mathf.Clamp(Player.transform.position.x, CameraMoveRangeX_Min, CameraMoveRangeX_Max))
        {
            CameraFlag = true;
        }
        else
        {
            CameraFlag = false;
        }

        if(Player.transform.position.y==Mathf.Clamp(Player.transform.position.y,CameraMoveRangeY_Min,CameraMoveRangeY_Max))
        {
            CameraFlag = true;
        }
        else
        {
            CameraFlag = false;
        }

        if (CameraFlag == true)
        {
            // カメラのtransform位置をプレイヤーと同じにする。計算されたオフセット距離によるずれも加える
            transform.position = Player.transform.position + offset;
        }


    }


}

  


