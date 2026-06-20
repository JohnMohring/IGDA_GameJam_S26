using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool isOn = false;

    public abstract void Activate();

}
