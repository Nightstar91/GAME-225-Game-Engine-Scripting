using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week12
{
    public class DataSaver : MonoBehaviour
    {
        public const string LEVEL_COMPLETE_ID = "Levels Complete";
        public const string NAME_ID = "Name";
        public const string MONEY_ID = "Money";

        public string mName;
        public int level;
        public float dollar
        {
            get
            {
                return m_dollar;
            }
            private set
            {
                m_dollar = value;
                PlayerPrefs.SetFloat(MONEY_ID, dollar);

                Debug.Log(PlayerPrefs.GetFloat(MONEY_ID, 0));
            }
        }

        private float m_dollar;

        public SaveData SaveData;




        [ContextMenu("Save Data")]
        void SaveDataTest()
        {
            PlayerPrefs.SetInt(LEVEL_COMPLETE_ID, 2);
            PlayerPrefs.SetString(NAME_ID, mName);
            PlayerPrefs.SetFloat(MONEY_ID, dollar);

            Debug.Log(JsonUtility.ToJson(SaveData));
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(SaveData));

            PlayerPrefs.Save();
        }

        [ContextMenu("Load Data")]
        void LoadData()
        {
            level =  PlayerPrefs.GetInt(LEVEL_COMPLETE_ID, 1);
            mName = PlayerPrefs.GetString(NAME_ID, "You have no name");
            m_dollar = PlayerPrefs.GetFloat(MONEY_ID, 0);

            SaveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString("SaveData"));
        }

        [ContextMenu("Add Dollar")]
        void AddDollar()
        {
            dollar++;
        }
    }
}
