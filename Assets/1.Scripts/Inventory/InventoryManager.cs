using Kinnly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slotUIList = new List<InventorySlot>();

    void Start()
    {
        foreach (var slot in slotUIList)
        {
            slot.ClearSlot(); // 이미지 꺼주기
        }
    }
    public void AddItem(ItemData item)
    {
        foreach (var slot in slotUIList)
        {
            if (!slot.iconImage.enabled) // 비어 있는 슬롯 찾기
            {
                slot.SetItem(item);
                Debug.Log($"[인벤토리] {item.displayName} 등록됨");
                return;
            }
        }

        Debug.Log("❗ 인벤토리에 빈 슬롯이 없습니다!");
    }
}
