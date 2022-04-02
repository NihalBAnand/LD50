using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableGeneric : MonoBehaviour
{
    //Interaction is the method called when the player interacts with an object that inherits this class.
    public abstract void Interaction(GameObject player);
}
