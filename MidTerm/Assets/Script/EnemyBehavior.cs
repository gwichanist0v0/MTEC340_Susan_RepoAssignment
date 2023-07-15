using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey.Utils;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Transform target;
    //Hardcode in

    NavMeshAgent agent; 
    

    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
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
        Vector3 target = GameObject.Find("Player").transform.position;
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("I KILLED HIM"); 

        }

    }
}
