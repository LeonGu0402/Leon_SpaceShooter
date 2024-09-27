using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float Radius;
    public float Speed;

    private float radian = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(Radius, Speed, planetTransform);
    }


    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        radian += Time.deltaTime;

        Vector3 direction = target.position + (new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0).normalized) * radius - transform.position;
        transform.position += direction * speed * Time.deltaTime;
        
    }
}
