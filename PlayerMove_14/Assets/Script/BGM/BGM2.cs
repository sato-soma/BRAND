using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM2 : MonoBehaviour
{
    GameObject[] tagObjects;
    public AudioSource audioSource;
    //int objs;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        tagObjects = GameObject.FindGameObjectsWithTag("BGM");
        Destroy(tagObjects[1]);

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "close")
        {
            Destroy(gameObject);
        }
    }
}
