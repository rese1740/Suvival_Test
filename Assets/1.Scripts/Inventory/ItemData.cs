using UnityEngine;

public enum ItemType
{
    Resource,
    Equipable,
    Consumable
}


// �Ҹ� ������ ��� �� ����� Conditions
public enum ConsumableType
{
    Hunger,
    Health
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPerfab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
}
