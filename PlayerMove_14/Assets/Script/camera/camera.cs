using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{

    public GameObject CameraTarget; //カメラが追尾するオブジェクト
    public Vector3 offset; //追尾するオブジェクトとの距離
    private Vector3 pos; //カメラのポジション

    public float MaxXposition; //どこまで追尾するか

    void Start()
    {
        updatePostion();
        pos.y = CameraTarget.transform.localPosition.y;
    }

    void LateUpdate()
    {
        if (CameraTarget.transform.position.x < MaxXposition)
        {
            updatePostion();
        }

       
    }

    void updatePostion()
    {
        pos.x = CameraTarget.transform.localPosition.x;
        pos.y = CameraTarget.transform.localPosition.y;
        pos.z = CameraTarget.transform.localPosition.z;
      
        transform.localPosition = pos + offset;
    }
}