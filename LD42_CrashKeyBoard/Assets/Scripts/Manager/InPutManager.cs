using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPutManager : SingleType<InPutManager>
{
    
    public Camera LeftCamera;
    public Camera RightCamera;
    public Camera UICamera;
    public bool CanGetKey = false;
    [HideInInspector]
    public MouseState mosueState=MouseState.Normal;
    public enum  MouseState
    {
        Normal,
        Cola,
        Hamber,
        Click
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	  
        #region ClickEvent

        switch (mosueState)
        {
            case MouseState.Normal:
                break;
            case MouseState.Cola:
                if (Input.GetMouseButton(0))
                {

                    RaycastHit[] hit = Physics.RaycastAll(RightCamera.ScreenPointToRay(Input.mousePosition), 100000);
                    if (hit.Length > 0)
                    {
                        Debug.Log("hit :" + hit[0].transform.name);
                        GameObject obj = PoolManager.instant.GetColo(hit[0].transform.position + new Vector3(-20, 0, 0));
                        obj.transform.parent = hit[0].transform;
                        hit[0].transform.GetComponent<PlaceHolder>().item = obj.GetComponent<Item>();
                        mosueState = MouseState.Normal;
                        StartCoroutine(ButtonEvrnt.instant.Colo_CD());
                        AnimateManager.instant.ClosePlace();
                       
                    }
                }
                return;
            case MouseState.Hamber:
                if (Input.GetMouseButton(0))
                {

                    RaycastHit[] hit = Physics.RaycastAll(RightCamera.ScreenPointToRay(Input.mousePosition), 100000);
                    if (hit.Length > 0)
                    {
                        Debug.Log("hit :" + hit[0].transform.name);
                        GameObject obj = PoolManager.instant.GetHamber(hit[0].transform.position);
                        obj.transform.parent = hit[0].transform;
                        // obj.transform.parent = hit[0].transform;
                        hit[0].transform.GetComponent<PlaceHolder>().item = obj.GetComponent<Item>();
                        mosueState = MouseState.Normal;
                        StartCoroutine(ButtonEvrnt.instant.Hamber_CD());
                        AnimateManager.instant.ClosePlace();

                    }
                }
                return;
            case MouseState.Click:
                if (Input.GetMouseButton(0))
                {

                    RaycastHit hit;

                    if (Physics.Raycast(LeftCamera.ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        
                        AnimateManager.instant.anima.SetTrigger("Click");
                        mosueState = MouseState.Normal;
                        StartCoroutine(ButtonEvrnt.instant.Click_CD());
                        UIManager.instant.SetAngryBar(10);

                    }
                }
                return;
            default:
                throw new ArgumentOutOfRangeException();
        }


        #endregion



	    if (Input.GetMouseButton(0))
	    {

	        RaycastHit hit;

	        if (Physics.Raycast(RightCamera.ScreenPointToRay(Input.mousePosition), out hit))
	        {
	            if (hit.transform.gameObject.layer == 12 && hit.transform.GetComponent<Colo>())
	            {
	                int index = AnimateManager.instant.placeHolderList.IndexOf(hit.transform.parent.GetComponent<PlaceHolder>());
	                hit.transform.parent.GetComponent<PlaceHolder>().item = null;
	                KeyBoardManager.instant.DistroidGroup(index);
	                hit.transform.GetComponent<BoxCollider>().enabled = false;
	                StartCoroutine(PushDownColo(hit.transform));
	            }

                
	            if (hit.transform.gameObject.layer == 9&&CanGetKey)
	            {
	                if (hit.transform.GetComponent<Key>().KesState!=Key.KeyState.Destroied)
                    {
                        Debug.Log(hit.transform.name);
                        hit.transform.GetComponent<Key>().KesState = Key.KeyState.Destroied;
                        hit.transform.GetComponentInChildren<MeshRenderer>().enabled = false;
                        UIManager.instant.SetAngryBar(5);
                    }
                  
	            }
	        }
	    }

    }

    IEnumerator PushDownColo(Transform t)
    {
        t.rotation = Quaternion.Euler(new Vector3(359, 0, 0));
        while ( t.rotation.eulerAngles.x>300)
        {
            Debug.Log(t.rotation.eulerAngles.x);
            t.Rotate(-90 * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        t.rotation=Quaternion.Euler(new Vector3(0, 0, 0));
       PoolManager.instant.SetColo(t.gameObject);
        UIManager.instant.SetAngryBar(20);
        
        
    }
}
