using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletBehavior : MonoBehaviour
{

    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rigid;
    private Tilemap tilemap; 



    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * speed;
        tilemap = FindObjectOfType<Tilemap>(); // Find the Tilemap component in the scene


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.GetComponent<TilemapCollider2D>() != null || collision.GetComponent<Tilemap>() != null)
        {
            Destroy(this.gameObject);
        }


    }

}
