using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambaKipKip : MonoBehaviour
{
    private int sans=1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            sans = Random.Range(1, 1000);
            if (sans < 10)
            {
                GetComponent<Light>().enabled = false;
            }
            else
            {
                GetComponent<Light>().enabled = true;
            }
        }
        else GetComponent<Light>().enabled = false;

    }
}
