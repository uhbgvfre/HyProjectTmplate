using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    [Multiline]
    public List<string> strings = new List<string>();

    private TextMeshProUGUI m_TextCache;
    private TextMeshProUGUI m_Text => m_TextCache = GetComponent<TextMeshProUGUI>();

    [SerializeField] private UnityEvent m_OnStringsSet;
    [SerializeField] private UnityEvent m_OnTextUpdated;

    public void SetStrings(List<string> strs)
    {
        if (strs == null) return;
        strings = strs;
        m_OnStringsSet?.Invoke();
    }

    private void Update()
    {
        var langIdx = GetLangIdx();
        string txt = string.Empty;

        if (langIdx >= strings.Count) return;

        txt = strings[langIdx];

        if (m_Text.text != txt)
        {
            m_Text.text = txt;
            m_OnTextUpdated?.Invoke();
        }
    }

    private int GetLangIdx() => 0 /* TODO: Source of lang idx */;
}