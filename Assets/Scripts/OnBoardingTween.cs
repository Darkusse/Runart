using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnBoardingTween : MonoBehaviour
{
    public Transform[] box;
    public Transform profilPanel;

    public GameObject onBoardingPanel;
    public GameObject mapPage;
    public GameObject navBar;
    public GameObject activeProfil;


    public Text textBtn;

    public Image dotsOnBoarding;
    public Sprite[] spriteArray;

    private int clicked = 0;


    // Start is called before the first frame update
    private void Start()
    {
        profilPanel.localScale = Vector2.zero;
        box[1].localPosition = new Vector2(Screen.width*2, 0);
        box[2].localPosition = new Vector2(Screen.width*2, 0);
        mapPage.SetActive(false);
        navBar.SetActive(false);
        
    }

 
    // Click on next button
    public void NextOnBoarding()
    {

        clicked++;

        if (clicked < 3)
        {
           box[clicked - 1].LeanMoveLocalX(-Screen.width, 0.5f);
           box[clicked].LeanMoveLocalX(0, 0.7f).setEaseOutExpo();
            dotsOnBoarding.sprite = spriteArray[clicked-1];

        }
        else
        {
            profilPanel.LeanScale(Vector2.one, 0.25f);
            navBar.SetActive(true);
            activeProfil.SetActive(true);
            onBoardingPanel.SetActive(false);
           
            //Use destroy method on onBoarding panel 
        }

        if (clicked == 2)
        {
            textBtn.text = "Go !";
        }
    }



    
}
