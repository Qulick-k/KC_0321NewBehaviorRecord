using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem 
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static void Init() 
    {
        if (!Directory.Exists(SAVE_FOLDER))          //如果有Save Folder
        {
            Directory.CreateDirectory(SAVE_FOLDER);  //在Save Folder建立資料
        }
    }
    public static void Save(string saveString) 
    {
        int saveNumber = 1; 
        while(File.Exists("save_" + saveNumber + ".txt"))
        {
            saveNumber++;
        }
        File.WriteAllText(SAVE_FOLDER + "save" + saveNumber + ".txt", saveString);
    }

}
