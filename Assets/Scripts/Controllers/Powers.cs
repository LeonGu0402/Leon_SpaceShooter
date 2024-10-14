
using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Powers : MonoBehaviour
{
    public GameObject player;
    public float spinSpeed = 60f;
    public float spinRadius = 1f;

    private Vector3 offset;
    private float radian = 0;
    private float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
        float currentAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        radian += currentAngle;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetKey(KeyCode.R))
        {
            PowersSpin1(spinRadius, spinSpeed, player.transform.position);
        }

        if (Input.GetKey(KeyCode.E))
        {
            PowersSpin2(spinRadius, spinSpeed, player.transform.position);
        }


    }

    public void PowersSpin1(float radius, float speed, Vector3 player)
    {
        
        float rotationSpeed = speed * Time.deltaTime * Mathf.Deg2Rad;

        radian += rotationSpeed;

        Vector3 direction = player + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
        transform.position = direction;
    }

    public void PowersSpin2(float radius, float speed, Vector3 player)
    { 
        float rotationSpeed = speed * Time.deltaTime * Mathf.Deg2Rad;
        radian += rotationSpeed;

        Vector3 direction = player + offset + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
        transform.position = direction;
    }
}
