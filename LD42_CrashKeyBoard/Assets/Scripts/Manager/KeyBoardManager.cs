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

        
    }

    public Dictionary<int, KeyGroup> keyGroupsDic=new Dictionary<int, KeyGroup>();
    [Header("键位")]
    public List<KeyGroup> keyGroups;
	// Use this for initialization
    public Material NormalKey;

    public Material PollutedKey;

    public void ShowKeyGroup()
    {
        
        foreach (KeyGroup keyGroup in keyGroups)
        {
            
            foreach (var key in keyGroup.keys)
            {
                if (key.KesState==Key.KeyState.Normal)
                {
                    keyGroup.Effect.SetActive(true);
                    break;
                }
            }
        }

    }

    public void CloseKeyGroup()
    {
        foreach (var keyGroup in keyGroups)
        {
            keyGroup.Effect.SetActive(false);
        }
    }
   public  void ClearKeyBoard()
    {
        foreach (var keyGroup in keyGroups)
        {
            foreach (var key in keyGroup.keys)
            {
                key.transform.GetComponentInChildren<MeshRenderer>().material= NormalKey;
            }
           
        }
    }

    public void CheckKeyBoard()
    {
        foreach (var keyGroup in keyGroups)
        {
            foreach (var key in keyGroup.keys)
            {
                if (key.KesState==Key.KeyState.Normal)
                {
                    return;
                }
            }
        }

        AnimateManager.instant.anima.SetBool("HasAngery",true);
    }

    public void DistroidGroup(int index)
    {
        foreach (var key in keyGroups[index].keys)
        {
            key.KesState = Key.KeyState.Polluted;
            key.GetComponentInChildren<MeshRenderer>().material = PollutedKey;
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


