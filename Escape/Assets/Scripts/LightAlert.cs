using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAlert : MonoBehaviour
{
    public bool myLightAlert=false;
    private void Start()
    {
         myLightAlert = false;
    }
    public void OnTriggerExit(Collider collider)
    {
        string KimDokundu = collider.gameObject.name;  

        if (KimDokundu.Equals("Kid"))          
        {
            myLightAlert = false;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {

        string KimDokundu = collider.gameObject.name; 

        if (KimDokundu.Equals("Kid"))          
        {
            myLightAlert = true;
        }
       
    }
}
