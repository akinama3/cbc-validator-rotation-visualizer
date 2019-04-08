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
        var yaml = new YamlStream();
        yaml.Load(sr);

        var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
        var items = (YamlSequenceNode) yaml.Documents[0].RootNode;
        foreach (var item in items)
        {
            
            Debug.Log("-----------");
            Debug.Log(item["slot"].ToString());
            Debug.Log("-xxxx");
            foreach (YamlMappingNode validator in item["validators"])
            {
                
            }

            Debug.Log(item["validators"]);
            Debug.Log("-xxxx");
            /*
            foreach (var validatorItem in item["validators"].AllNodes)
            {
                Debug.Log("xxx");
                Debug.Log("xxx");
                
            }
            */
            Debug.Log(item["validators"].ToString());
            Debug.Log("-----------");

        }

        return default(List<MessageModel>);
    }
}