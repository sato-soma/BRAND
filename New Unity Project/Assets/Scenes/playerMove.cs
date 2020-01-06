using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMove : MonoBehaviour
{
    public NavMeshAgent player;
    public GameObject target;

    void Start()
    {
        player = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            player.destination = target.transform.position;
        }
    }
}
