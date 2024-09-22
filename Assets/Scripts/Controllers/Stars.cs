using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private bool draw = true;

    // Update is called once per frame
    void Update()
    {

        foreach (Transform t in starTransforms)
        {
            Vector3 position = t.position;
            Vector3 nextposition = starTransforms[starTransforms.IndexOf(t) + 1].position;

            if (draw)
            {
                drawLine(position, nextposition, drawingTime);
            }

        }


    }

    private void drawLine(Vector3 start, Vector3 end, float time)
    {
        draw = false;

        Debug.DrawLine(start, end, Color.white, time);

        draw = true;
        
    }
}
