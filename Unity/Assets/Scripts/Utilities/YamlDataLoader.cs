using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using Models;
using UnityEngine.Analytics;
using Debug = UnityEngine.Debug;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.NodeDeserializers;


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
        
        var json = serializer.Serialize(yamlObject);

        Debug.Log("-----------------");
        Debug.Log(json);
        Debug.Log("-----------------");    
        
        

        
        return default(List<MessageModel>);
    }
}