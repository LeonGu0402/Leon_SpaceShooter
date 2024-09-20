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

    public float speed = 3f;

    Vector3 velocity = Vector3.zero;

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerMovement();
    }


    public void playerMovement()
    {
        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y += speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y -= speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x += speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x -= speed;
        }

        velocity = velocity.normalized * speed;

        transform.position += velocity * Time.deltaTime;

    }
}
