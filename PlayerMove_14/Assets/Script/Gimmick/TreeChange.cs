using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChange : MonoBehaviour
{
    private bool ChangeTreeFlag; //オブジェクトが切り替わっているか

    // Start is called before the first frame update
    void Start()
    {
        ChangeTreeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (ReturmGame.RestartFlag[0] == true)
        {
            ChangeTreeFlag = true;
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }

        // イベント後オブジェクトが切り替える
        if (ChangeTreeFlag == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            ReturmGame.RestartFlag[0] = false;
        }

        // キー操作はデバック用↓
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    transform.GetChild(0).gameObject.SetActive(true);
        //    transform.GetChild(1).gameObject.SetActive(false);
        //}
        //else if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    transform.GetChild(1).gameObject.SetActive(true);
        //    transform.GetChild(0).gameObject.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    ChangeTreeFlag = true;
        //}
    }
}
