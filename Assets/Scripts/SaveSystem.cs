using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem 
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static void Init() 
    {
        if (!Directory.Exists(SAVE_FOLDER))          //�p�G��Save Folder
        {
            Directory.CreateDirectory(SAVE_FOLDER);  //�bSave Folder�إ߸��
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
