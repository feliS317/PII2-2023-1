using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(HealthPlayer player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData data = new SavedData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavedData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData data = formatter.Deserialize(stream) as SavedData;
            stream.Close();

            return data;
        }
        else{
            Debug.LogError("Archivo no encontrado en " + path);
            return null;
        }
    }
}
