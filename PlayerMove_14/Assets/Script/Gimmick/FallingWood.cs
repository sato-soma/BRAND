using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWood : MonoBehaviour
{
    public float count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // Invoke("Fall", 2); //invoke("呼び出す関数", 秒数);
            GetComponent<Rigidbody>().isKinematic = false;

            if(count > 0)
            {
                count += 1.0f / 60.0f;
            }

            if(count > 1f)
            {
                gameObject.SetActive(true);
                count = -1;
            }
        }
    }

    



}
