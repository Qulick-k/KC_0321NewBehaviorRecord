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
    //�U�Ӥ��ʮ઺�Ȧs���A�Ψӧ����ഫ���x�s��counterNumber�� 
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

    public static string objectname; //Ū�����~�W��
    public static string playerName; //Ū�����a����

    public void Awake()
    {
        SaveSystem.Init();
    }

    public static void SaveInteract(int judge)
    {   //SAVE
        int counterName = judge;
        if (counterName == 1)  // 1�ΨӧP�_ContainerCounter
        {
            containerCache = containerCache + 1;
            counterNumber = containerCache;
            counter = "ContainerCounter";
        }
        if (counterName == 2) // 2�ΨӧP�_SqueezeCounter
        {
            squeezerCache = squeezerCache + 1;
            counterNumber = squeezerCache;
            counter = "SqueezeCounter";
        }
        if (counterName == 3) // 3�ΨӧP�_ClearCounter
        {
            clearCounterCache = clearCounterCache + 1;
            counterNumber = clearCounterCache;
            counter = "ClearCounter";
        }
        if (counterName == 4) // 4�ΨӧP�_CuttingCounter
        {
            cuttingCounterCache = cuttingCounterCache + 1;
            counterNumber =cuttingCounterCache;
            counter = "CuttingCounter";
        }
        if (counterName == 5) // 5�ΨӧP�_PlatesCounter
        {
            platesCounterCache = platesCounterCache + 1;
            counterNumber = platesCounterCache;
            counter = "PlatesCounter";
        }
        if (counterName == 6) // 6�ΨӧP�_DeliveryCounter
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

        //objectname = KitchenObjectSO.objectName;//���X���~�W��(�|������)
        //playerName = KitchenGameMultiplayer.playerName; //�����a�m�W(���ȡA���ઽ�����)

        SaveObject saveObject = new SaveObject
        {
            //Player = playerName,
            CounterCount = counterNumber,
            Counter = counter,
            //Object = objectname,
            PlayerInteraction = playerInteraction,
            Time = Hr + ":" + Min + ":" + Sec,
        };

        string json = JsonUtility.ToJson(saveObject); //JsonUtility:��{��������л\(��s)

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
    private class SaveObject        //�bJSON�̪������r��
    {
        public int CounterCount;
        //public string Player;
        //public string Object;
        public string Counter;
        public string PlayerInteraction;
        public string Time;
    }
}
