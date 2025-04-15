using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;
    

    public string GetInteractPrompt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

    public void OnInteract()
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null && item != null)
        {
            inventory.AddItem(item);
            Destroy(gameObject); // ������ ������ ����
        }
    }
}
