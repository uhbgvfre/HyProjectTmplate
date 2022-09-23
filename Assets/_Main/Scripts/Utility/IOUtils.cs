using System;
using System.IO;
using System.Linq;

public static class IOUtils
{
    // 遍歷並操作目錄中的檔案，依檔案名稱的後綴或副檔名(忽略大小寫)
    public static void ForeachFilesBySuffixCaseInsensitive(string folderPath, string[] searchPatterns, Action<string> onPathHandle)
    {
        if (!Directory.Exists(folderPath)) return;

        var comparison = System.StringComparison.InvariantCultureIgnoreCase;
        var files = Directory.EnumerateFiles(folderPath, "*.*").Where(s => AnyEndWith(s, searchPatterns));
        foreach (var file in files)
        {
            onPathHandle?.Invoke(file);
        }

        bool AnyEndWith(string file, params string[] exts)
        {
            foreach (var ext in exts)
            {
                if (file.EndsWith(ext, comparison)) return true;
            }
            return false;
        }
    }

    // 遍歷並操作目錄中的子目錄，依子目錄名稱的前綴(忽略大小寫)
    public static void ForeachDirectoriesByPrefixCaseInsensitive(string rootFolderPath, string prefix, Action<string> onPathHandle)
    {
        if (!Directory.Exists(rootFolderPath)) return;

        var option = new EnumerationOptions() { MatchCasing = MatchCasing.CaseInsensitive };
        var folders = Directory.EnumerateDirectories(rootFolderPath, $"{prefix}*", option);
        foreach (var folder in folders)
        {
            onPathHandle?.Invoke(folder);
        }
    }
}