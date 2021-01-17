using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public bool myAlert=false;
    private void Start()
    {
        myAlert = false;
    }
    public void OnTriggerExit(Collider collider)
    {
        string KimDokundu = collider.gameObject.name;  // Nerelere dokundu?

        if (KimDokundu.Equals("Kid"))          // Düştü mü?
        {
            myAlert = false;
            print("Kurtuldu");
        }
    }

    public void OnTriggerEnter(Collider collider)
    {

        string KimDokundu = collider.gameObject.name;  // Nerelere dokundu?

        if (KimDokundu.Equals("Kid"))          // Düştü mü?
        {
            myAlert = true;
            print(collider);
        }
       
    }
}
