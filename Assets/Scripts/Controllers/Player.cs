//using Codice.Client.BaseCommands;
//using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject powerupPrefab;
    public Transform bombsTransform;

    //public float speed;
    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;

    public float radarRadius;
    public int circlePoints;
    public float powerRadius;
    public int powerNumbers;


    private float acceleration;
    private float deceleration;
    private Vector3 currentVelocity;
    private float maxSpeedSqr;


    private void Start()
    {
        //acceleration = maxSpeed / accelerationTime;
        //deceleration = maxSpeed / decelerationTime;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        maxSpeedSqr = maxSpeed * maxSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerups(powerRadius, powerNumbers, powerupPrefab);
        }


    }

    private void FixedUpdate()
    {
        playerMovement();
        EnemyRadar(radarRadius, circlePoints);

        
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
    //public void playerMovement()
    //{
    //    //acceleration
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        if (velocity.y >= maxSpeed)
    //        {
    //            velocity.y = maxSpeed;
    //        }
    //        else
    //        {
    //            velocity += Vector3.up * acceleration * Time.deltaTime;
    //        }
    //    }

    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        if (velocity.y <= -maxSpeed)
    //        {
    //            velocity.y = -maxSpeed;
    //        }
    //        else
    //        {
    //            velocity += Vector3.down * acceleration * Time.deltaTime;
    //        }
    //    }

    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        if (velocity.x >= maxSpeed)
    //        {
    //            velocity.x = maxSpeed;
    //        }
    //        else
    //        {
    //            velocity += Vector3.right * acceleration * Time.deltaTime;
    //        }
    //    }

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        if (velocity.x <= -maxSpeed)
    //        {
    //            velocity.x = -maxSpeed;
    //        }
    //        else
    //        {
    //            velocity += Vector3.left * acceleration * Time.deltaTime;
    //        }
    //    }

    //    ////deceleration
    //    if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        if (velocity.y > 0 && velocity.y != 0)
    //        {
    //            velocity -= Vector3.up * deceleration * Time.deltaTime;
    //        }

    //        if (velocity.y < 0 && velocity.y != 0)
    //        {
    //            velocity -= Vector3.down * deceleration * Time.deltaTime;
    //        }

    //        if (velocity.x > 0 && velocity.x != 0)
    //        {
    //            velocity -= Vector3.right * deceleration * Time.deltaTime;
    //        }

    //        if (velocity.x < 0 && velocity.x != 0)
    //        {
    //            velocity -= Vector3.left * deceleration * Time.deltaTime;
    //        }
    //    }

    //    //Debug.Log(velocity);
    //    transform.position += velocity * Time.deltaTime;
    //}

    public void playerMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.down;

        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;

        if (moveDirection.sqrMagnitude > 0)
        {
            currentVelocity += Time.deltaTime * acceleration * moveDirection;
            if (currentVelocity.sqrMagnitude > maxSpeedSqr)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            Vector3 velocityDelta = Time.deltaTime * deceleration * currentVelocity.normalized;
            if (velocityDelta.sqrMagnitude > currentVelocity.sqrMagnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }

        transform.position += currentVelocity * Time.deltaTime;
    }


    public void EnemyRadar(float radius, int pointNum)
    {
        //determain the radians
        float radians = Mathf.Deg2Rad * (360 / pointNum);

        if ((enemyTransform.position - transform.position).magnitude <= radius)
        {
            for (int i = 0; i < pointNum; i++)
            {
                Vector3 dot1 = transform.position + (new Vector3 (Mathf.Cos(radians * (i + 1)), Mathf.Sin(radians * (i + 1)), 0).normalized) * radius;
                Vector3 dot2 = transform.position + (new Vector3 (Mathf.Cos(radians * (i + 2)), Mathf.Sin(radians * (i + 2)), 0).normalized) * radius;

                Debug.DrawLine(dot1, dot2, Color.red);
            }
        }
        else
        {
            for (int i = 0; i < pointNum; i++)
            {
                Vector3 dot1 = transform.position + (new Vector3 (Mathf.Cos(radians * (i + 1)), Mathf.Sin(radians * (i + 1)), 0).normalized) * radius;
                Vector3 dot2 = transform.position + (new Vector3 (Mathf.Cos(radians * (i + 2)), Mathf.Sin(radians * (i + 2)), 0).normalized) * radius;

                Debug.DrawLine(dot1, dot2, Color.green);
            }
        }
    }


    public void SpawnPowerups(float radius, int numberOfPowerups, GameObject powers)
    {
        float radians = Mathf.Deg2Rad * (360 / numberOfPowerups);

        for (int i = 1; i <= numberOfPowerups; i++)
        {
            Vector3 position = transform.position + (new Vector3(Mathf.Cos(radians * (i)), Mathf.Sin(radians * (i)), 0).normalized) * radius;

            Instantiate(powers, position, Quaternion.identity);
        }
    }



}
