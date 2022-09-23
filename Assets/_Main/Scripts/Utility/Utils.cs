using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utils
{
    // 檢確數量(類池化)：若物件未達數量則實例化並訂製初始化，過量則禁用多餘的物件
    public static void CheckQuantity<T>(this RectTransform parent, int targetQuantity, List<T> cachedElements, Action<T> onCreate = null) where T : Component
    {
        bool isQtyNonEq = targetQuantity != cachedElements.Count;
        while (targetQuantity > cachedElements.Count)
        {
            T newSample = UnityEngine.Object.Instantiate(cachedElements[0], parent);
            cachedElements.Add(newSample);
            onCreate?.Invoke(newSample);
        }

        for (int i = 0; i < cachedElements.Count; i++)
        {
            bool isValidUnit = i < targetQuantity;
            cachedElements[i].gameObject.SetActive(isValidUnit);
        }

        if (isQtyNonEq) LayoutRebuilder.ForceRebuildLayoutImmediate(parent);
    }
}