using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Transform playerTransform;

    private Vector3 enemyPosition;
    private Vector3 playerPosition;
    private Vector3 velocity;

    private void Start()
    {
        
    }

    private void Update()
    {
        enemyPosition = transform.position;
        playerPosition = playerTransform.position;

        trackPlayer(enemyPosition, playerPosition, speed);


    }

    private void trackPlayer(Vector3 enemy, Vector3 player, float speed)
    {
        Vector3 direction = player - enemy;
        Vector3 velocity = direction.normalized * speed * Time.deltaTime;

        transform.position += velocity;

    }

}
