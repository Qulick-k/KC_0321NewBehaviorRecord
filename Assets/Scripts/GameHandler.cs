using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using System.Data;
using UnityEditor;

public class GameHandler : MonoBehaviour
{
    //各個互動桌的暫存器，用來把資料轉換並儲存到counterNumber中 
    public static int containerCache = 0;  //ContainerCounter
    public static int squeezerCache = 0;  //SqueezeCounter
    public static int clearCounterCache = 0;  //ClearCounter
    public static int cuttingCounterCache = 0;  //CuttingCounter
    public static int platesCounterCache = 0;  //PlatesCounter
    public static int deliverCounterCache = 0;  //DeliveryCounter
    public static int cuttingCounterCache2 = 0;

    public static int counterNumber = 0;
    public static int counterNumber2 = 0;
    public static string counter;
    public static string playerInteraction = "(E)Put/PutDown";
    public static string playerInteraction2 = "(F)Cut";

    public static int sysHour;
    public static int sysMin;
    public static int sysSec;
    public static string Hr;
    public static string Min;
    public static string Sec;

    public static string objectname; //讀取物品名稱
    public static string playerName; //讀取玩家的值

    public void Awake()
    {
        SaveSystem.Init();
    }

    public static void SaveInteract(int judge)
    {   //SAVE
        int counterName = judge;
        if (counterName == 1)  // 1用來判斷ContainerCounter
        {
            containerCache = containerCache + 1;
            counterNumber = containerCache;
            counter = "ContainerCounter";
        }
        if (counterName == 2) // 2用來判斷SqueezeCounter
        {
            squeezerCache = squeezerCache + 1;
            counterNumber = squeezerCache;
            counter = "SqueezeCounter";
        }
        if (counterName == 3) // 3用來判斷ClearCounter
        {
            clearCounterCache = clearCounterCache + 1;
            counterNumber = clearCounterCache;
            counter = "ClearCounter";
        }
        if (counterName == 4) // 4用來判斷CuttingCounter
        {
            cuttingCounterCache = cuttingCounterCache + 1;
            counterNumber =cuttingCounterCache;
            counter = "CuttingCounter";
        }
        if (counterName == 5) // 5用來判斷PlatesCounter
        {
            platesCounterCache = platesCounterCache + 1;
            counterNumber = platesCounterCache;
            counter = "PlatesCounter";
        }
        if (counterName == 6) // 6用來判斷DeliveryCounter
        {
            deliverCounterCache = deliverCounterCache + 1;
            counterNumber = deliverCounterCache;
            counter = "DeliveryCounter";
        }

        sysHour = System.DateTime.Now.Hour;
        sysMin = System.DateTime.Now.Minute;
        sysSec = System.DateTime.Now.Second;
        Hr = sysHour.ToString();
        Min = sysMin.ToString();
        Sec = sysSec.ToString();

        //objectname = KitchenObjectSO.objectName;//取出物品名稱(尚未找到值)
        //playerName = KitchenGameMultiplayer.playerName; //取玩家姓名(找到值，不能直接抓值)

        SaveObject saveObject = new SaveObject
        {
            //Player = playerName,
            CounterCount = counterNumber,
            Counter = counter,
            //Object = objectname,
            PlayerInteraction = playerInteraction,
            Time = Hr + ":" + Min + ":" + Sec,
        };

        string json = JsonUtility.ToJson(saveObject); //JsonUtility:把現有的資料覆蓋(更新)

        SaveSystem.Save(json);  
        Debug.Log(json);
    }
    public static void SaveInteractAlternative(int judge2)
    {   //SAVE
        int counterName2 = judge2;
        if(counterName2 == 1) 
        {
            cuttingCounterCache2 = cuttingCounterCache2 + 1;
            counterNumber2 = cuttingCounterCache2;
        }

        sysHour = System.DateTime.Now.Hour;
        sysMin = System.DateTime.Now.Minute;
        sysSec = System.DateTime.Now.Second;
        Hr = sysHour.ToString();
        Min = sysMin.ToString();
        Sec = sysSec.ToString();

        SaveObject saveObject = new SaveObject
        {
            CounterCount = counterNumber2,
            Counter = "CuttingCounter",
            PlayerInteraction = playerInteraction2,
            Time = Hr + ":" + Min + ":" + Sec,
        };
        string json = JsonUtility.ToJson(saveObject);

        SaveSystem.Save(json);  
        Debug.Log(json);
    }
    private class SaveObject        //在JSON裡的說明字串
    {
        public int CounterCount;
        //public string Player;
        //public string Object;
        public string Counter;
        public string PlayerInteraction;
        public string Time;
    }
}
