﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    private static string _path;

    private static Dictionary<int, string> _levels = new Dictionary<int, string>();

    private Dictionary<string, Color32> _paintButton = new Dictionary<string, Color32>
    {
        {"Gold"   , new Color32(255, 223, 0 , 255) },
        {"Silver" , new Color32(192, 192, 192, 255)},
        {"Bronze" , new Color32(205, 127, 50, 255)   } 
    };


    private void Start()
    {
        _path = Path.Combine(Application.dataPath, "Save.json");
        string json = "";

        if (File.Exists(_path))
            json = File.ReadAllText(_path);

        if (json.Length != 0) 
            OpenLevels(json);

        Button _1level = GameObject.FindGameObjectWithTag("Level").GetComponent<Button>();
        _1level.interactable = true;
    }


    private void OpenLevels(string json)
    {
        var passedLevels = JsonConvert.DeserializeObject<Dictionary<int, string>>(json);

        List <Button> buttons = new List<Button>();

        var tempButtons = GameObject.FindGameObjectsWithTag("Level");
        foreach (var buttonGameObject in tempButtons)
            buttons.Add(buttonGameObject.GetComponent<Button>());
        

        for (int i = 0; i < buttons.Count; ++i)
        {
            if (i <= passedLevels.Count) // открой все пройденные уровни и следующий
                buttons[i].interactable = true;

            if (i < passedLevels.Count) // // раскрасить кнопку пройденных уровней в золотой, серебрянный или бронзовый цвет
                buttons[i].GetComponent<Image>().color = _paintButton[passedLevels[i]]; 
        }
    }



    public static void MakeSave(int indexOfLevel, string result)
    {
        _levels[indexOfLevel] = result;

        string json = JsonConvert.SerializeObject(_levels);

        File.WriteAllText(Path.Combine(Application.dataPath, "Save.json"), json);
    }
}
