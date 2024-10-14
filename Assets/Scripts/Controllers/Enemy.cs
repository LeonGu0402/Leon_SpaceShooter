using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Transform playerTransform;
    public float rotationSpeed;

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
        rotationEnemy(playerTransform, rotationSpeed);
    }

    private void trackPlayer(Vector3 enemy, Vector3 player, float speed)
    {
        Vector3 direction = player - enemy;
        Vector3 velocity = direction.normalized * speed * Time.deltaTime;

        transform.position += velocity;

    }

    public void rotationEnemy(Transform player, float speed)
    {
        //Debug.DrawLine(transform.position, player.position, Color.green);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        //float facing = transform.rotation.eulerAngles.z + 90;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        ////if (angle - facing <= 0)
        ////{
        ////    if (facing > angle)
        ////    {
        ////        transform.Rotate(0, 0, -speed * Time.deltaTime);
        ////    }
        ////}
        ////else
        ////{
        ////    if (facing < angle)
        ////    {
        ////        transform.Rotate(0, 0, speed * Time.deltaTime);
        ////    }
        ////}


    }

}
