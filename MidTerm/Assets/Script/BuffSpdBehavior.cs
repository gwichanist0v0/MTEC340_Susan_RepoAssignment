using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpdBehavior : MonoBehaviour
{
    private MonkTest monkTest;
    private PlayerBehavior playerBehavior;

    // Start is called before the first frame update
    void Start()
    {
        GameObject monkTesty = GameObject.Find("MokneyTest");
        monkTest = monkTesty.GetComponent<MonkTest>();

        transform.position += new Vector3(0.5f, 0.5f, 0f);

        GameObject Player = GameObject.Find("Player"); 
        playerBehavior = Player.GetComponent<PlayerBehavior>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {

            //StartCoroutine(playerBehavior.SpeedUp());
            playerBehavior.SpeedUP();

            Vector3 spdPosition = transform.position;

            Vector3Int spdPositionInt = new Vector3Int(
                     ((int)spdPosition.x > 0 ? (int)spdPosition.x : (int)spdPosition.x - 1), ((int)spdPosition.y > 0 ? (int)spdPosition.y : (int)spdPosition.y - 1), 0);

            monkTest.DestroySpeed(spdPositionInt);
            Destroy(gameObject);
        }

    }

}
