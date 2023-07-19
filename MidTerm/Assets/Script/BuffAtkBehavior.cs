using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAtkBehavior : MonoBehaviour
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
            playerBehavior.AttakGo(); 

            Vector3 atkPosition = transform.position;

            Vector3Int atkPositionInt = new Vector3Int(
                     ((int)atkPosition.x > 0 ? (int)atkPosition.x : (int)atkPosition.x - 1), ((int)atkPosition.y > 0 ? (int)atkPosition.y : (int)atkPosition.y - 1), 0);

            monkTest.DestroyAttack(atkPositionInt);
            Destroy(gameObject);
        }

    }
}
