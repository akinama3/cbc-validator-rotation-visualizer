using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;
using YamlDotNet.Serialization;
using MiniJSON;


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
        Debug.Log(jsonStr);

        IList slotList = (IList)Json.Deserialize(jsonStr);
        foreach (IDictionary slot in slotList)
        {
            Debug.Log("------------------------");
            var slotNo = int.Parse((string)slot["slot"]);
            IList validators = (IList) slot["validators"];
            foreach (IDictionary validator in validators)
            {
                Debug.Log(validator["name"]);
                IDictionary state = (IDictionary) validator["state"];
                IList messages = (IList) state["messages"];
                foreach (IDictionary message in messages)
                {
                    var hash = (string)message["hash"];
                    var parentHash = (string)message["parent_hash"];
                    var receiverSlot = int.Parse((string)message["receiver_slot"]);
                    var sender = (string)message["sender"];
                    var senderSlot = int.Parse((string) message["sender_slot"]);
                    IDictionary estimate = (IDictionary) message["estimate"];
                    var estimatedHash = (string) estimate["hash"];
                    var estimatedParentHash = (string) estimate["parent_hash"];
                    Debug.Log(hash);
                    Debug.Log(parentHash);
                    Debug.Log(receiverSlot);
                    Debug.Log(sender);
                    Debug.Log(senderSlot);
                    Debug.Log(estimatedHash);
                    Debug.Log(estimatedParentHash);

                    IList justification = (IList) message["justification"];
                    foreach (IDictionary m in justification)
                    {
                        var justificationHash = (string)m["message_hash"];
                        var justificationSender = (string) m["sender"];
                        Debug.Log("---justification-------");
                        Debug.Log(justificationHash);
                        Debug.Log(justificationSender    );
                        Debug.Log("---juustification-------");
                    }
                }
            }
            Debug.Log("------------------------");
        }

        return default(List<MessageModel>);
    }
}

/*
 *   - current_slot: 1
    name: v0
    state:
      messages:
      - estimate:
          hash: 92689018377936
          parent_hash: null
        hash: 24381726710723
        justification: []
        parent_hash: null
        receiver_slot: 0
        sender: v1
        sender_slot: 0
      - estimate:
          hash: 4369441391216
          parent_hash: 92689018377936
        hash: 76958864578603
        justification:
        - message_hash: 24381726710723
          sender: v1
        parent_hash: 24381726710723
        receiver_slot: 0
        sender: v0
        sender_slot: 0
*/