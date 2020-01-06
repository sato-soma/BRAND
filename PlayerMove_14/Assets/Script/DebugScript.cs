using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject StartPoint; //スタート位置
    public GameObject MidPoint; //中間スタート位置

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //イベント前にワープ
        {
            Player.transform.position = new Vector3(289f, -1.3f, -0.25f);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        
    }
}
