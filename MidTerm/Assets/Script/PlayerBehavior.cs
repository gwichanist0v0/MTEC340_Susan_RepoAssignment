using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] float _speed = 1f;
    [SerializeField] KeyCode _downKey;
    [SerializeField] KeyCode _upKey;
    [SerializeField] KeyCode _leftKey;
    [SerializeField] KeyCode _rightKey;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_upKey))
        {
            transform.position += new Vector3(0, _speed, 0) * Time.deltaTime;

        }

        if (Input.GetKey(_downKey))
        {
            transform.position -= new Vector3(0, _speed, 0) * Time.deltaTime;

        }

        if (Input.GetKey(_rightKey))
        {
            transform.position += new Vector3(_speed, 0, 0) * Time.deltaTime;

        }

        if (Input.GetKey(_leftKey))
        {
            transform.position -= new Vector3(_speed, 0, 0) * Time.deltaTime;

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("WallCollide");
    }

   
}

