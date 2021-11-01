using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static GameObject FloatingTextBubble(Vector3 position, string text, Color c){
        EffectsManager effectsManager = FindObjectOfType<EffectsManager>();
        GameObject floatingText = Instantiate( effectsManager.TextPrefab, position, Quaternion.identity );
        floatingText.GetComponent<TMP_Text>().color = c;
        floatingText.GetComponent<HintPopUp>().displayText = text;
        return floatingText;
    }

}
