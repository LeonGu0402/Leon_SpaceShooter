using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCircleExercise : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float radius = 3;
    public float delayInSeconds = 0.5f;

    public List<float> anglesList;

    private int currentAngle = 0;
    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            anglesList.Add(Random.value * 360);
        }

        transform.position += offset;
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    currentAngle = (currentAngle + 1) % anglesList.Count;
        //}

        if (elapsedTime > delayInSeconds)
        {
            currentAngle = (currentAngle + 1) % anglesList.Count;
            elapsedTime = 0;
        }



        float radians = Mathf.Deg2Rad * anglesList[currentAngle];
        float xPos = Mathf.Cos (radians);
        float yPos = Mathf.Sin (radians);

        Vector3 endPoint = transform.position + new Vector3 (xPos, yPos, 0) * radius;

        Debug.DrawLine (transform.position, endPoint, Color.magenta);


    }
}
