using System.Collections.Generic;
using System.IO;
using Debug = UnityEngine.Debug;
using YamlDotNet.Serialization;


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
        var deserializer = new DeserializerBuilder().Build();
        var yamlObject = deserializer.Deserialize(sr);
        var serializer = new SerializerBuilder()
            .JsonCompatible()
            .Build();
        
        var jsonStr = serializer.Serialize(yamlObject);

        Debug.Log("-----------------");
        Debug.Log(jsonStr);
        Debug.Log("-----------------");

        
        return default(List<MessageModel>);
    }
}