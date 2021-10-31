using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothing;

    public Vector3 min, max;
    [Range(0,1)]
    public float moveCameraTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPos.x >= moveCameraTrigger)
        {
            Vector3 targetPosition = target.position + offset;
            //Verify if the targetPosition is out of bound or not
            //Limit it to the min and max values
            Vector3 boundPosition = new Vector3(
                Mathf.Clamp(targetPosition.x, min.x, max.x),
                targetPosition.y,
                transform.position.z); // modify if need to track y axis arizes

            Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothing);
            transform.position = smoothPosition;

            //min.x = smoothPosition.x; //Uncomment if we don't want them to be able to walk back
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.up) * 5;
        Gizmos.DrawRay(new Vector3(max.x, 0, 0), direction);
        Gizmos.DrawRay(new Vector3(min.x, 0, 0), direction);
    }
}
