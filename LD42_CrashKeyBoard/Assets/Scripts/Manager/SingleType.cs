using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleType< T> : MonoBehaviour where T:MonoBehaviour
{
    private static T _instant;

    public static T instant
    {
        get
        {
            if (_instant==null)
            {
                _instant=FindObjectOfType<T>();
            }
            return _instant;
        }
       private set { _instant = value; }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
