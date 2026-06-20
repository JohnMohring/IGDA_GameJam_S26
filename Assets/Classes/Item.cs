using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int quantity;
    public bool DestroyOnPickup = true;
    public bool goToInventory = true;
    public enum ItemType
    {
        KeyItem,
        Consumable
    }
    public Inventory playerInventory;

    public virtual void Pickup()
    {
        // If Inventory Item, add Item to Inventory
        if (goToInventory)
        {
            playerInventory.Add(this, quantity);
        }

        if (DestroyOnPickup)
        {
            Destroy(gameObject);
        }
    }

}
