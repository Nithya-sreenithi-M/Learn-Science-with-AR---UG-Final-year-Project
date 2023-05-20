using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbInteraction : MonoBehaviour, IVirtualButtonEventHandler
{
    VirtualButtonBehaviour[] virtualButtonBehaviours;
    string vbName;
    public GameObject []elements=new GameObject[37];
    int []displayedelements = new int[37];
    int counter = 0;
    GameObject presentobj;
    int yes = 0;
    int no = 0;
    int []forestIndex = new int[] { 1, 7, 16, 17, 29, 30 };
    

    int points = 0;

    void Start()
    {
        //Register with the virtual buttons TrackableBehaviour
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
            virtualButtonBehaviours[i].RegisterEventHandler(this);

        elements[0].SetActive(true);
        displayedelements[0] = 1;
       for(int i=0;i<displayedelements.Length;i++)
        {
            displayedelements[i] = -1;
        }
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        vbName = vb.VirtualButtonName;



        if (vbName == "next")
        {
            if (counter < elements.Length)
            {
                Deactivate();
                nextsprites();
            }
        }

        else if (vbName == "yes")
        {
            checkans_yes();

        }
        else if (vbName == "no")
        {
            checkans_no();
        }
       
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

   

    void Deactivate()
    {
        foreach(GameObject e in elements )
        {
            e.SetActive(false);
        }
       
    }

    void nextsprites()
    {
        int flag = 0;
        counter++;
        if (counter<elements.Length)
        {
            elements[counter].SetActive(true);
            foreach(int a in forestIndex)
            {
                if (counter==a)
                {
                    flag = 1;
                    yes = 1;
                    no = 0;
                    break;
                }
            }
            if (flag==0)
            {
                no = 1;
                yes = 0;
            }
        }
    }

    void checkans_yes()
    {
        if (yes==1)
        {
            Debug.Log("yes forest");

        }
        else
        {
            Debug.Log("not a forest");
        }
        
        
    }
    void checkans_no()
    {
        if(no==1)
        {
            Debug.Log("yes not a forest");
        }
        else
        {
            Debug.Log("wormg");
        }
    }


}
