using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

// 【外部色表】
public static class AppColorSheet
{
    private static Dictionary<string, Color> s_Colors = new Dictionary<string, Color>();
    private static string k_ColorSheetPath => Application.streamingAssetsPath + "/_AppTheme/ColorSheet.jsonc";

    // 嘗試取得顏色
    public static Color GetColor(string colorKey) => s_Colors.ContainsKey(colorKey) ? s_Colors[colorKey] : default;

    // 自動於場景加載前初始化
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init() => LoadColorSheet();

    private static void LoadColorSheet()
    {
        if (!File.Exists(k_ColorSheetPath)) return;

        try
        {
            string sheetRawStr = File.ReadAllText(k_ColorSheetPath);

            var sheetJO = JsonConvert.DeserializeObject<Dictionary<string, string>>(sheetRawStr);
            bool hasSheetElements = sheetJO != null || sheetJO.Count > 0;
            if (!hasSheetElements) return;

            foreach (var kv in sheetJO)
            {
                Color? c = ParseColor(kv.Value);
                if (string.IsNullOrWhiteSpace(kv.Key) || !c.HasValue) continue;
                s_Colors.Add(kv.Key, c.Value);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("[AppColorSheetLoadErr]");
            Debug.Log("[JsonParseErr]: " + e.Message);
            throw;
        }

        Color? ParseColor(string hexRawStr)
        {
            hexRawStr = hexRawStr.Trim();
            if (!hexRawStr.StartsWith("#")) { hexRawStr = hexRawStr.Insert(0, "#"); }
            return ColorUtility.TryParseHtmlString(hexRawStr, out Color c) ? c : null;
        }
    }
}