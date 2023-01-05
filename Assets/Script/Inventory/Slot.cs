using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Items ItemInSlot;
    public int AmountInSlot;

    RawImage icon;
    TextMeshProUGUI txt_amount;

    public void SetStats()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        icon = GetComponentInChildren<RawImage>();
        txt_amount = GetComponentInChildren<TextMeshProUGUI>();

        icon.texture = ItemInSlot.icon;
        txt_amount.text = $"{AmountInSlot}x";
    }

}
