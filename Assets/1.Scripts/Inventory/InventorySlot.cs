using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image iconImage;

    public void SetItem(ItemData item)
    {
        iconImage.sprite = item.icon;
        iconImage.enabled = true; // �� ���̴� ������ �ѱ�
    }

    public void ClearSlot()
    {
        iconImage.sprite = null;
        iconImage.enabled = false;
    }
}
