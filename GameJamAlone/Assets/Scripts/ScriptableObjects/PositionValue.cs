using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Postion", menuName = "Values/Position", order = 1)]
public class PositionValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue; //Value of the object (Stays the same throught the game)

    [HideInInspector]
    public Vector2 RuntimeValue; //Value used during the game

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue; //Reset value once the game stops
    }

    public void OnBeforeSerialize()
    {
        
    }
}
