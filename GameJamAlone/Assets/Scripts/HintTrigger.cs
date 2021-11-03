using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    public string text;
    public Color c;

    private GameObject popUp;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        popUp = GameManager.FloatingTextBubble(other.transform.position, text, c);
    }

    void OnTriggerExit2D(Collider2D other) {
        Destroy(popUp);
    }
}
