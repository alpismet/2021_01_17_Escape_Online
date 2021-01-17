using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent enemy;

    public GameObject target;
    public Alert myAlertCheck;
    public LightAlert myLightAlertCheck;
    public GameObject myLight;

    private int sayac = 100;
    private int xy = 0;
    private int artiEksi = 0;

    private int sans; 


    // Start is called before the first frame update
    void Start()
    {
        sans = Random.Range(1, 1000);
        xy = Random.Range(0, 2);
        artiEksi = Random.Range(0, 2);
        enemy = GetComponent<NavMeshAgent>();
        bool myAlertChecker = myAlertCheck.GetComponent<Alert>().myAlert;
        bool myLightAlertChecker = myLightAlertCheck.GetComponent<LightAlert>().myLightAlert;

    }

    // Update is called once per frame
    void Update()
    {
        //Lamba kıp kıp
        sans = Random.Range(1, 1000);

        //AI Tetik
        bool myAlertChecker = myAlertCheck.GetComponent<Alert>().myAlert;
        if (myAlertChecker==false)
        {
            if (sayac <= 0) VoltaReset();
            else Volta();
        }
        else
        {
            enemy.SetDestination(target.transform.position);
        }

        //Enemy Light Tetik
        bool myLightAlertChecker = myLightAlertCheck.GetComponent<LightAlert>().myLightAlert;
        if (myLightAlertChecker == false)
        {
            //myLight.GetComponent<Light>().enabled = false;
            myLight.gameObject.SetActive(false);
        }
        else
        {
            if (sans < 10)
            {
                //myLight.GetComponent<Light>().enabled = false;
                myLight.gameObject.SetActive(false);
            }
            else
            {
                //myLight.GetComponent<Light>().enabled = true;
                myLight.gameObject.SetActive(true);
            }
        }



        

    }
    private void VoltaReset()
    {
        xy = Random.Range(0, 2);
        artiEksi = Random.Range(0, 2);
        sayac = 100;
        Volta();
    }
        private void Volta()
    {
        if(xy == 0)
        {
            if (artiEksi == 0)
            {
                enemy.SetDestination(enemy.transform.position + new Vector3(10,0,0));
            }else enemy.SetDestination(enemy.transform.position - new Vector3(10,0,0));
            sayac--;
        }
        else
        {
            if (artiEksi == 0)
            {
                enemy.SetDestination(enemy.transform.position + new Vector3(0,0,10));
            }
            else enemy.SetDestination(enemy.transform.position - new Vector3(0,0,10));
            sayac--;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        string KimeDokundu = collision.gameObject.name;
        if (KimeDokundu.Equals("RightWall") && KimeDokundu.Equals("LeftWall") && KimeDokundu.Equals("BackWall") && KimeDokundu.Equals("L_Wall") && KimeDokundu.Equals("R_Wall"))
            VoltaReset();
        else if (KimeDokundu.Equals("Kid"))
            FindObjectOfType<Scripts>().GameOver();


    }
}
