using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateManager : SingleType<AnimateManager>
{
    
    
    [Header("占位符,按位置放")]
    public List<PlaceHolder> placeHolderList;

    public  PlaceHolder LeftHand;

    public PlaceHolder RightHand;
    [HideInInspector]
    public  Animator anima;
	// Use this for initialization
	void Start ()
	{
	    anima = GetComponent<Animator>();
        ClosePlace();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 判断是否有食物，返回食物位置
    /// </summary>
    /// <returns></returns>
    public void HasFood()
    {
        int ItemPlace=-1;
        for (int i = 0; i < placeHolderList.Count; i++)
        {
            
                if (placeHolderList[i].item != null) 
                {
                    if (placeHolderList[i].item is Colo || placeHolderList[i].item is Hanburger)
                    {
                        ItemPlace = i;
                    }
                }
            
        }
        if (ItemPlace!=-1)
        {
            HandToGet(ItemPlace);


        }
    }

    public void HandToGet(int place)
    {
        anima.Play("HandGet_"+place);
       
    }

    public void GetItem(int place)
    {
        if (placeHolderList[place].item==null)
        {
            anima.SetBool("HasFood",false);
            return;
        }
        placeHolderList[place].item.GetComponent<BoxCollider>().enabled = false;


        if (place < 5)
            placeHolderList[place].item.transform.parent = LeftHand.transform;
        else
            placeHolderList[place].item.transform.parent = RightHand.transform;

        placeHolderList[place].item.transform.localPosition=Vector3.zero;
        placeHolderList[place].item = null;


    }
    public void ShowFreePlace()
    {
        Debug.Log(placeHolderList.Count);
        foreach (var placeHolder in placeHolderList)
        {
            if (placeHolder.item==null)
            {
                placeHolder.GetComponent<ParticleSystem>().Play();
             
            }
        }
    }

    public void ClosePlace()
    {
        foreach (var placeHolder in placeHolderList)
        {
            placeHolder.GetComponent<ParticleSystem>().Stop();
        }
    }
}
