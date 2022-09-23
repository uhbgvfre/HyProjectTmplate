using UnityEngine;

public class AppConfig
{
    // 自動於場景加載前初始化
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        INIParser ini = new INIParser();
        ini.Open(Application.streamingAssetsPath + "/AppConfig.ini");
        PopulateParams(ini);
        ini.Close();
    }

    private static void PopulateParams(INIParser ini)
    {
        // Debug
        IsDebugMode = ini.ReadValue("Debug", "IsDebugMode", false);

        // Basic
        IdleCheckDelay = (float)ini.ReadValue("Basic", "IdleCheckDelay", 30f);
    }

    // Debug
    public static bool IsDebugMode { get; private set; }

    // Basic
    public static float IdleCheckDelay { get; private set; }
}