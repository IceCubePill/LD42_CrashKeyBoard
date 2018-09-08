using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvrnt : SingleType<ButtonEvrnt>
{
    public Button ColoBTN;
    public Button HamberBTN;
    public Button ExitBTN;
    public Button ClickBTN;
    public Button LightBTN;

    public Light light;

    public float ColoCD = 5f;
    public float HamberCD = 5f;
    public float ClickCd = 5f;
    public float CloseLight = 10f;

    public float EatingTime = 5;
    public float EatingRestTime = 0;
    public void Colo_Button()
    {
        AnimateManager.instant.ShowFreePlace();

        InPutManager.instant.mosueState = InPutManager.MouseState.Cola;

    }
    public IEnumerator Colo_CD()
    {
        ColoBTN.interactable = false;
        yield return new WaitForSeconds(ColoCD);
        ColoBTN.interactable = true;
    }
    public void Hamber_Button()
    {
        AnimateManager.instant.ShowFreePlace();

        InPutManager.instant.mosueState = InPutManager.MouseState.Hamber;

    }

    public IEnumerator Hamber_CD()
    {
        HamberBTN.interactable = false;
        yield return new WaitForSeconds(HamberCD);
        HamberBTN.interactable = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Click_Button()
    {


        InPutManager.instant.mosueState = InPutManager.MouseState.Click;

    }

    public IEnumerator Click_CD()
    {
        ClickBTN.interactable = false;
        yield return new WaitForSeconds(ClickCd);
        ClickBTN.interactable = true;
    }

    public void Light_Button()
    {


        StartCoroutine(light_CD());
        
    }

    public IEnumerator light_CD()
    {
        light.intensity = 0;
        HamberBTN.interactable = false;
        AnimateManager.instant.anima.SetBool("HasLight", false);
        yield return new WaitForSeconds(HamberCD);
        light.intensity = 1;
        HamberBTN.interactable = true;
        AnimateManager.instant.anima.SetBool("HasLight", true);
    }

    public void Eating_Button()
    {
        StartCoroutine(Eating_CD());
    }
    public IEnumerator Eating_CD()
    {
        AnimateManager.instant.anima.SetBool("HasFood", true);
        if (EatingRestTime > 0)
            yield return new WaitForSeconds(EatingRestTime);
        else
            yield return new WaitForSeconds(EatingTime);
        AnimateManager.instant.anima.SetBool("HasFood", false);
    }
}
