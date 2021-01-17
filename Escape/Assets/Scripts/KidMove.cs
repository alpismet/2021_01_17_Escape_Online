using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMove : MonoBehaviour
{

    public DynamicJoystick DynamicJoystick;
    public float speed=30;
    private Vector3 direction = new Vector3 (0,0,0);
    private bool mouseDowned = false;


    public void FixedUpdate()
    {
        direction = Vector3.forward * DynamicJoystick.Vertical + Vector3.right * DynamicJoystick.Horizontal;
        //GetComponent<Rigidbody>().AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddForce(direction * speed);

        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (Quaternion.LookRotation(direction) != new Quaternion(0.0f, 0.0f, 0.0f, 1.0f))
            {
                transform.rotation = Quaternion.LookRotation(direction);
                //  transform.Translate(direction * Time.deltaTime, Space.World);
            }
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        }

    }

    
    private void OnCollisionEnter(Collision collision)
    {
        string KimeDokundu = collision.gameObject.name;
        if (KimeDokundu.Equals("Finish"))
            FindObjectOfType<Scripts>().GameOver();
    }

        
}
