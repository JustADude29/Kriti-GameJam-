
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SaveState (PlayerStats stats, List<TileInfo> tiles, VehicleState vstate){
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath+"/save.bi";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameState saveState = new GameState(stats,tiles,vstate);
        formatter.Serialize(stream, saveState);

        stream.Close();
    }

    public static GameState LoadState(){
        string path = Application.persistentDataPath + "/save.bi";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            GameState loadState = formatter.Deserialize(stream) as GameState;
            stream.Close();

            return loadState;
        }   
        else{
            Debug.Log("File not present");
            return null;
        }
    }
}
