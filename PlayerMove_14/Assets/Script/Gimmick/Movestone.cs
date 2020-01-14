using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movestone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ReturmGame.RestartFlag0 == true)
        {
            if (transform.position.y < 6)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
            }
            else
            {
                ReturmGame.RestartFlag0 = false;
            }
        }

       
    }
}
