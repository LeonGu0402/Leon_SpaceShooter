using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;


    private bool Flag;
    private Vector3 movePosition;
    private Vector3 asteroidPosition;

    // Start is called before the first frame update
    void Start()
    {
        Flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        asteroidPosition = transform.position;


        AsteroidMovement(asteroidPosition, moveSpeed, maxFloatDistance, arrivalDistance);

    }

    public void AsteroidMovement(Vector3 rock, float speed, float spawnRange, float distance)
    {
        if (Flag)
        {
            movePosition = rock + new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), 0);
            Flag = false;
        }

        Vector3 direction = movePosition - rock;
        Vector3 velocity = direction.normalized * speed * Time.deltaTime;
        
        if (direction.magnitude < distance)
        {
            Flag = true;
        }

        transform.position += velocity;

    }

}
