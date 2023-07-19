using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using CodeMonkey.Utils;
public class CoinBehavior : MonoBehaviour
{
    private MonkTest monkTest; 

    private void Start()
    {
       

        GameObject monkTesty = GameObject.Find("MokneyTest");

        //if (monkTesty != null)
        //{
        //    Debug.Log("FOUND MONK"); 
        //}

        monkTest = monkTesty.GetComponent<MonkTest>();

        //if (monkTest != null)
        //{
        //    Debug.Log("MonkTest script found!");
        //}

        transform.position += new Vector3(0.5f, 0.5f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

 
            // Check if the colliding object is a coin
        if (collider.CompareTag("Player"))
        {
            
            Vector3 coinPosition = transform.position;


            Vector3Int coinPositionInt = new Vector3Int(
                ((int)coinPosition.x > 0 ? (int)coinPosition.x : (int)coinPosition.x - 1), ((int)coinPosition.y > 0 ? (int)coinPosition.y : (int)coinPosition.y - 1), 0);
                //Vector3Int coinPositionInt = new Vector3Int((int)coinPosition.x, (int)coinPosition.y, 0);
            //Debug.Log(coinPositionInt);


            monkTest.DestroyCoin(coinPositionInt); 
            Destroy(gameObject);

            UpdateScore();



        }
        
    }

    private void UpdateScore()
    {
        GameBehaviors.Instance.Score += 1;
    }



}
