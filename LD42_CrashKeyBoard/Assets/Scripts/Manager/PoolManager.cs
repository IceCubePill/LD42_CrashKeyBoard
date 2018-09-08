using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingleType<PoolManager> {
    List<GameObject> ColoList=new List<GameObject>();
    List<GameObject> HamberList = new List<GameObject>();

    public GameObject GetColo(Vector3 pos)
    {
        GameObject obj;
        if (ColoList.Count>1)
        {
            obj = ColoList[0];
            ColoList.Remove(ColoList[0]);
            obj.transform.position = pos;
            obj.GetComponentInChildren<MeshRenderer>().enabled = true;
            obj.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
             obj = Instantiate(Resources.Load<GameObject>("Perfabs/Cola_Final"), pos,
                Quaternion.Euler(0, 0, 0));
        }
        return obj;
    }
    public void  SetColo(GameObject colo)
    {
        colo.transform.parent = this.transform;
        colo.transform.localPosition=Vector3.zero;
        ColoList.Add(colo);
        colo.GetComponentInChildren<MeshRenderer>().enabled = false;
    }

    public GameObject GetHamber(Vector3 pos)
    {
        GameObject obj;
        if (HamberList.Count > 1)
        {
            obj = HamberList[0];
            HamberList.Remove(HamberList[0]);
            obj.transform.position = pos;
            obj.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        else
        {
            obj = Instantiate(Resources.Load<GameObject>("Perfabs/Hamburger"), pos,
                Quaternion.Euler(0, 0, 0));
        
        }
        return obj;
    }
    public void SetHamber(GameObject hamber)
    {
        hamber.transform.parent = this.transform;
        hamber.transform.localPosition = Vector3.zero;
        HamberList.Add(hamber);
        hamber.GetComponentInChildren<MeshRenderer>().enabled = false;
    }
}
