using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinetoMouse : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;
        Debug.DrawLine(Vector3.zero, mouseWorldPosition, Color.green);

        float angleInDegrees = Mathf.Atan2(mouseWorldPosition.y, mouseWorldPosition.x) * Mathf.Rad2Deg;

        print($"current angle is: {angleInDegrees}");
    }
}
