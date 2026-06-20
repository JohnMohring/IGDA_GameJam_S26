using UnityEditorInternal.VersionControl;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    Dictionary<Item, int> ItemsInInventory;

    public void Add(Item item, int quantity)
    {
        ItemsInInventory.Add(item, quantity);
    }

}
