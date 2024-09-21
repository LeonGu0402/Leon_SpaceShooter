using Codice.Client.BaseCommands;
using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //public float speed;
    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;

    private float acceleration;
    private float deceleration;
    private Vector3 velocity = Vector3.zero;



    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerMovement();
    }

    //Task1A
    //public void playerMovement()
    //{
    //    velocity = Vector3.zero;

    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        velocity.y += speed;
    //    }

    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        velocity.y -= speed;
    //    }

    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        velocity.x += speed;
    //    }

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        velocity.x -= speed;
    //    }

    //    velocity = velocity.normalized * speed;

    //    transform.position += velocity * Time.deltaTime;

    //}


    //Task1B
    public void playerMovement()
    {
        //acceleration
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (velocity.y >= maxSpeed)
            {
                velocity.y = maxSpeed;
            }
            else
            {
                velocity += Vector3.up * acceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (velocity.y <= -maxSpeed)
            {
                velocity.y = -maxSpeed;
            }
            else
            {
                velocity += Vector3.down * acceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (velocity.x >= maxSpeed)
            {
                velocity.x = maxSpeed;
            }
            else
            {
                velocity += Vector3.right * acceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (velocity.x <= -maxSpeed)
            {
                velocity.x = -maxSpeed;
            }
            else
            {
                velocity += Vector3.left * acceleration * Time.deltaTime;
            }
        }

        ////deceleration
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            if (velocity.y > 0 && velocity.y != 0)
            {
                velocity -= Vector3.up * deceleration * Time.deltaTime;
            }

            if (velocity.y < 0 && velocity.y != 0)
            {
                velocity -= Vector3.down * deceleration * Time.deltaTime;
            }

            if (velocity.x > 0 && velocity.x != 0)
            {
                velocity -= Vector3.right * deceleration * Time.deltaTime;
            }

            if (velocity.x < 0 && velocity.x != 0)
            {
                velocity -= Vector3.left * deceleration * Time.deltaTime;
            }
        }













        Debug.Log(velocity);
        transform.position += velocity * Time.deltaTime;
    }










}
