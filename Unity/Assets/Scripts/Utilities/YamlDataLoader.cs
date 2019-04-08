using UnityEngine;
using System.Collections.Generic;
using System.IO;
using YamlDotNet;


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
        StreamReader sr = new StreamReader(path);
        string text = sr.ReadToEnd();
        Debug.Log("-------------");
        Debug.Log(text);
        Debug.Log(text.Length);
        Debug.Log("-------------");
        
        return default(List<MessageModel>);
    }
}