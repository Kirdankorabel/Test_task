using GateScripts;
using System.Collections.Generic;
using TrackScripts;
using UnityEngine;

public class Levels : ScriptableObject
{
    public static List<LevelInfo> levels = new List<LevelInfo>()
    {
        new LevelInfo
        (
        new List<GateInfo>()
        {
            new GateInfo (-5, 3, true, false, false),
            new GateInfo (5, 3, true, false, false),
            new GateInfo (5, 3, true, false, false),
            new GateInfo (5, 0, true, false, true),
            new GateInfo (4, 0, true, false, false),
            new GateInfo (4, -10, true, false, false),
            new GateInfo (4, -10, true, false, false)
        },
        new List<Vector3> () 
        {
            new Vector3(0.5f, 2, 16),
            new Vector3(-0.5f, 2, 16),
            new Vector3(-0.5f, 2, 34),
            new Vector3(0.5f, 2, 50),
            new Vector3(0.5f, 2, 52),
        },
        30
        ),

        new LevelInfo
        (
        new List<GateInfo>()
        {
            new GateInfo (-5, 2, true, false, false),
            new GateInfo (3, 2, true, false, false),
            new GateInfo (5, 20, true, false, false),
            new GateInfo (5, 20, true, false, false),
            new GateInfo (3, 2, true, false, false),
            new GateInfo (3, 2, true, false, false),
            new GateInfo (-5, 10, true, false, false),
            new GateInfo (-4, 10, true, false, false),
            new GateInfo (-4, 10, true, false, false),
            new GateInfo (10, -5, true, false, false),
            new GateInfo (-10, -5, false, false, false),
            new GateInfo (10, -5, false, false, false),
                },
               
        new List<Vector3> ()
        {
            new Vector3(0.5f, 2, 16),
            new Vector3(-0.5f, 2, 16),
            new Vector3(-0.5f, 2, 34),
            new Vector3(0.5f, 2, 50),
            new Vector3(0.5f, 2, 52),
            new Vector3(0.5f, 2, 65),
            new Vector3(-0.5f, 2, 65),
            new Vector3(-0.5f, 2, 83),
            new Vector3(0.5f, 2, 88),
            new Vector3(0.5f, 2, 100),
        },
        30
        ),
                
        new LevelInfo
        (
        new List<GateInfo>()
        {
            new GateInfo (-5, 2, true, false, false),
            new GateInfo (14, 25, true, false, false),
            new GateInfo (14, 25, true, false, false),
            new GateInfo (-5, -12, true, false, false),
            new GateInfo (2, 2, true, false, false),
            new GateInfo (4, 2, true, false, false),
            new GateInfo (2, -25, true, false, false),
            new GateInfo (2, 2, true, false, false),
            new GateInfo (12, 52, false, false, false),
            new GateInfo (3, 6, true, true, false),
            new GateInfo (4, 2, true, false, false),
            new GateInfo (-10, -102, true, false, false),
                },
               
        new List<Vector3> ()
        {
            new Vector3(0.5f, 2, 16),
            new Vector3(-0.5f, 2, 16),
            new Vector3(-0.5f, 2, 34),
            new Vector3(0.5f, 2, 50),
            new Vector3(0.5f, 2, 52),
            new Vector3(0.5f, 2, 65),
            new Vector3(-0.5f, 2, 65),
            new Vector3(-0.5f, 2, 83),
            new Vector3(0.5f, 2, 88),
            new Vector3(0.5f, 2, 100),
        },
        30
        ),
    };

    public static LevelInfo GetLevel(int level)
    {
        if (level >= 0 && level < levels.Count)
            return levels[level];
        else
        {
            Debug.Log("level not found");
            Application.Quit();
            return null;
        }
    }
}


