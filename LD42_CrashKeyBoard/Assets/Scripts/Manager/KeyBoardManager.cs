using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManager : SingleType<KeyBoardManager>
{
    [Serializable]
    public class KeyGroup
    {
        /// <summary>
        /// 键区对应位置
        /// </summary>
        public int Place;

        public  List<Key> keys;

        public  Key FindKeyByName(string name)
        {
            foreach (var key in keys)
                if (key.name==name)
                    return key;
             return null;
        }

        public GameObject Effect;
        private bool m_isLocking = false;

        public bool isLocking
        {
            get { return m_isLocking; }
            set
            {
                m_isLocking = value;
                Effect.SetActive(!value);
            }
        }
    }

    public Dictionary<int, KeyGroup> keyGroupsDic=new Dictionary<int, KeyGroup>();
    [Header("键位")]
    public List<KeyGroup> keyGroups;
	// Use this for initialization
    public Material NormalKey;

    public Material PollutedKey;
    void ClearKeyBoard()
    {
        foreach (var keyGroup in keyGroups)
        {
            foreach (var key in keyGroup.keys)
            {
                key.transform.GetComponentInChildren<MeshRenderer>().material= NormalKey;
            }
            keyGroup.isLocking = true;
        }
    }
	void Start () {

	    foreach (var keyGroup in keyGroups)
	    {
	        keyGroupsDic.Add(keyGroup.Place,keyGroup);
	    }
	    ClearKeyBoard();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


