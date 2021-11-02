using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{

    public float distance;

    public LayerMask boxMask;

    GameObject box;

    private bool isPushing;
    // Start is called before the first frame update
    void Start()
    {
        isPushing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        //Debug.Log(hit.collider);

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(KeyCode.E) && !isPushing){
            box = hit.collider.gameObject;

            isPushing = true;

            box.GetComponent<FixedJoint2D>().connectedBody = this.transform.parent.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            //box.GetComponent<FixedJoint2D>().autoConfigureConnectedAnchor = false;
            //Debug.Log("I'm here");
        }
        else if (Input.GetKeyDown(KeyCode.E) && isPushing)
        {
            //box.GetComponent<DistanceJoint2D>().autoConfigureConnectedAnchor = true;
            box.GetComponent<FixedJoint2D> ().enabled = false;
            isPushing = false;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
