using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public enum KeyState
    {
        Normal,
        Polluted,
        Destroied
    }

    public KeyState KesState = KeyState.Normal;
    /// <summary>
    /// 破坏这个键将导致的警惕性,暂时不修改
    /// </summary>
    public int vigilance=10;

    public string name;
    // Use this for initialization
    void Start ()
    {
        name = gameObject.name;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}


