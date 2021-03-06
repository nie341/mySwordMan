﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmLibrary : MonoBehaviour 
{
    static DataTable s_rhythmData;

    public static void Init()
    {
        s_rhythmData = DataManager.GetData("RhythmData");
    }

    public static string GetRhythmID(string content)
    {
        try
        {
            string tmp = content.Substring(content.Length - 1, 1);

            for (int i = 0; i < s_rhythmData.TableIDs.Count; i++)
            {
                if (DataGenerateManager<RhythmDataGenerate>.GetData(s_rhythmData.TableIDs[i]).m_Content.Contains(tmp))
                {
                    return s_rhythmData.TableIDs[i];
                }
            }

            //Debug.Log("查无此韵 " + content);
        }
        catch(Exception e)
        {
            Debug.LogError("GetRhythmID Error :->" +content + "<- Exception : " + e.ToString());
        }


        return "未知";
    }

    public static List<string> GetRhythmList()
    {
        return s_rhythmData.TableIDs;
    }


}
