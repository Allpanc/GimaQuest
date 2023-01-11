using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class JsonMaster
{

    public static void Save<T>(List<T> dataList, string jsonFileName)
    {
        if (!jsonFileName.Contains(".json"))
            jsonFileName.Concat(".json");

        string path = Application.persistentDataPath + @"\" + jsonFileName;
        string jsonString = JsonHelper.ToJson<T>(dataList.ToArray(), true);

        if (!File.Exists(path))
            File.Create(path);

        File.WriteAllText(path, jsonString);
        Debug.LogWarning(dataList + " saved to " + jsonFileName);
    }

    public static List<T> ParseResource<T>(string jsonResourceName)
    {
        if (jsonResourceName.Contains(".json"))
            jsonResourceName.Replace(".json", string.Empty);

        TextAsset fileTextAsset = Resources.Load<TextAsset>(jsonResourceName);
        string jsonString = fileTextAsset.text;

        //Debug.LogWarning("Data parsed from " + jsonResourceName);
        return JsonHelper.FromJson<T>(jsonString).ToList();
    }
}
