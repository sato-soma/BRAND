using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event0 : MonoBehaviour
{
    public static bool Event_0Flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Event_0Flag == true)
        {
            if (PlayerState.Event0EndFlag == false)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event"))
                {
                    SceneManager.LoadScene("event0");
                    PlayerState.Event0EndFlag = true;
                }
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_0Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Event_0Flag = false;        
        }
    }
}
