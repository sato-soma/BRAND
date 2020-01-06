using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{

    public GameObject objTarget;
    public Vector3 offset;
    private Vector3 pos;

    void Start()
    {
        updatePostion();
        pos.y = objTarget.transform.localPosition.y;
    }

    void LateUpdate()
    {
        updatePostion();
    }

    void updatePostion()
    {
        pos.x = objTarget.transform.localPosition.x;
        pos.y = objTarget.transform.localPosition.y;
        pos.z = objTarget.transform.localPosition.z;

         
        
        
        transform.localPosition = pos + offset;
    }
}