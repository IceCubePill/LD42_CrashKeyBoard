using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateManager : SingleType<AnimateManager>
{
    
    
    [Header("占位符,按位置放")]
    public List<PlaceHolder> placeHolderList;
	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 判断是否有食物，返回食物位置
    /// </summary>
    /// <returns></returns>
    public PlaceHolder HasFood()
    {
        foreach (var placeHolder in placeHolderList)
        {
            if (placeHolder.item != null) 
            {
                if (placeHolder.item is Colo || placeHolder.item is Hanburger)
                {
                    return placeHolder;
                }
            }
        }
        return null;
    }
}
