using UnityEngine;
using System.Collections.Generic;

public static class YamlDataLoader
{
    /// <summary>
    /// YAMLファイルからデータをロードして、MessageModelリストを生成する
    /// </summary>
    /// <param name="path">読み込み元YAMLファイルパス</param>
    /// <returns>List<MessageModel></returns>
    public static List<MessageModel> LoadAllMessageModelsFromYamlFile(string path)
    {
        Debug.Log(path);
        
        return default(List<MessageModel>);
    }
}