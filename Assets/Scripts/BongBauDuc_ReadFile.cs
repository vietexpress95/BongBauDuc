using UnityEngine;
using System;

public class BongBauDuc_ReadFile : MonoBehaviour
{
    public static BongBauDuc_ReadFile ins;

    public int tableSize;

    [System.Serializable]
    public class Level {
        public float a1;
        public float a2;
        public float a3;
        public float a4;
        public float a5;
        public float b1;
        public float b2;
        public float b3;
        public float b4;
        public float b5;
        public float c1;
        public float c2;
        public float c3;
        public float c4;
        public float c5;
    }

    [System.Serializable]
    public class LevelList
    {
        public Level[] levels;
    }

    public LevelList levelList = new LevelList();
    public TextAsset textAsset;

    private void Awake()
    {
        ins = this;    
    }
    
    void Start()
    {
        ReadCSV();
    }

    private void ReadCSV()
    {
        string[] data = textAsset.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);
        tableSize = data.Length / 15 - 1;
        levelList.levels = new Level[tableSize];

        Debug.Log("Đây là độ dài danh sách: " + tableSize.ToString());

        for(int i = 0; i < tableSize; i++)
        {
            levelList.levels[i] = new Level();

            levelList.levels[i].a1  = float.Parse(data[15 * (i + 1) + 0] == "" ? "-1" : data[15 * (i + 1) + 0]);
            levelList.levels[i].a2  = float.Parse(data[15 * (i + 1) + 1] == "" ? "-1" : data[15 * (i + 1) + 1]);
            levelList.levels[i].a3  = float.Parse(data[15 * (i + 1) + 2] == "" ? "-1" : data[15 * (i + 1) + 2]);
            levelList.levels[i].a4  = float.Parse(data[15 * (i + 1) + 3] == "" ? "-1" : data[15 * (i + 1) + 3]);
            levelList.levels[i].a5  = float.Parse(data[15 * (i + 1) + 4] == "" ? "-1" : data[15 * (i + 1) + 4]);

            levelList.levels[i].b1  = float.Parse(data[15 * (i + 1) + 5] == "" ? "-1" : data[15 * (i + 1) + 5]);
            levelList.levels[i].b2  = float.Parse(data[15 * (i + 1) + 6] == "" ? "-1" : data[15 * (i + 1) + 6]);
            levelList.levels[i].b3  = float.Parse(data[15 * (i + 1) + 7] == "" ? "-1" : data[15 * (i + 1) + 7]);
            levelList.levels[i].b4  = float.Parse(data[15 * (i + 1) + 8] == "" ? "-1" : data[15 * (i + 1) + 8]);
            levelList.levels[i].b5  = float.Parse(data[15 * (i + 1) + 9] == "" ? "-1" : data[15 * (i + 1) + 9]);

            levelList.levels[i].c1  = float.Parse(data[15 * (i + 1) + 10] == "" ? "-1" : data[15 * (i + 1) + 10]);
            levelList.levels[i].c2  = float.Parse(data[15 * (i + 1) + 11] == "" ? "-1" : data[15 * (i + 1) + 11]);
            levelList.levels[i].c3  = float.Parse(data[15 * (i + 1) + 12] == "" ? "-1" : data[15 * (i + 1) + 12]);
            levelList.levels[i].c4  = float.Parse(data[15 * (i + 1) + 13] == "" ? "-1" : data[15 * (i + 1) + 13]);
            levelList.levels[i].c5  = float.Parse(data[15 * (i + 1) + 14] == "" ? "-1" : data[15 * (i + 1) + 14]);
            Debug.Log(data[15 * (i + 1) + 14]);
        }
    }
}
