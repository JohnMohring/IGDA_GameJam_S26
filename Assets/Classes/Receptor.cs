using UnityEngine;
using UnityEngine.WSA;

public abstract class Receptor : MonoBehaviour
{
    public Interactable[] triggers;

    public abstract void OnActivated();

}
