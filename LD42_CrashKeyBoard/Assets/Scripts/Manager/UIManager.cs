using System.Collections;
using System.Collections.Generic;
using ProgressBar;
using UnityEngine;

public class UIManager : SingleType<UIManager>
{
    public ProgressBarBehaviour pbb;


    public  void SetAngryBar(int value)
    {
        pbb.Value += value;
        if (pbb.Value>=100)
        {
            pbb.Value = 100;
            AnimateManager.instant.anima.SetBool("HasAngery",true);
        }
        else if (pbb.Value<0)
            pbb.Value = 0;
        
       
    }
    // Use this for initialization
    void Start ()
    {
        pbb.Value = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
