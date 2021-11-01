using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameObject FloatingTextBubble(Vector3 position, string text, Color c){
        EffectsManager effectsManager = FindObjectOfType<EffectsManager>();
        GameObject floatingText = Instantiate( effectsManager.TextPrefab, position, Quaternion.identity );
        floatingText.GetComponent<TMP_Text>().color = c;
        floatingText.GetComponent<HintPopUp>().displayText = text;
        return floatingText;
    }

}
