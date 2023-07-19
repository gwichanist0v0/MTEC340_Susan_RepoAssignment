using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey.Utils;

public class EnemyBehavior : MonoBehaviour
{


    NavMeshAgent agent;
    private GameObject myPlayer; 
   
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.Find("Player");
        if (myPlayer != null)
        {
            Debug.Log("Found the player!");
        }

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        SetTargetPosition();
        

    }

    void SetTargetPosition()
    {
        Vector3 position = myPlayer.transform.position;
        agent.SetDestination(position); 
    }

}
