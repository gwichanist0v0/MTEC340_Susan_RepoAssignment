using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerBehavior : MonoBehaviour
{

    public float _speed = 1f;
    [SerializeField] KeyCode _downKey;
    [SerializeField] KeyCode _upKey;
    [SerializeField] KeyCode _leftKey;
    [SerializeField] KeyCode _rightKey;
    [SerializeField] GameBehaviors gameBehaviors;
    [SerializeField] WeaponBehavior weaponBehavior;
    
    bool isSpeedUp;


    // Start is called before the first frame update
    void Start()
    {
        isSpeedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameBehaviors.Instance.State == GameState.Play)
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

        

    }

    

    //public IEnumerator SpeedUp()
    //{
    //    _speed *= 2;

    //    Debug.Log(_speed);

    //    yield return new WaitForSeconds(5f);

    //    _speed /= 2;

    //    Debug.Log(_speed);
    //}

    public void SpeedUP()
    {
        if (!isSpeedUp)
        {
            _speed *= 2;
            isSpeedUp = true;

            Invoke(nameof(SpeedDown), 3f);
        }
    }

    private void SpeedDown()
    {
        _speed /= 2;
        isSpeedUp = false;
        Debug.Log(_speed);

    }

    public void AttakGo()
    {
        weaponBehavior.enabled = true;
        Invoke(nameof(AttackNo), 2f);
    }

    private void AttackNo()
    {
        weaponBehavior.enabled = false; 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
             Destroy(gameObject);
            

        }

    }



}

