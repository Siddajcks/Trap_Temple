using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
   public Transform firepoint;
   public GameObject arrow;
   float timebetween;
   public float starttimebetween;
    void Start()
    {
       timebetween = starttimebetween; 
    }

    // Update is called once per frame
    void Update()
    {
       if(timebetween <= 0)
        {
            Instantiate(arrow,firepoint.position,firepoint.rotation);  
            timebetween = starttimebetween;
        } 
        else
        {
            timebetween -= Time.deltaTime;
        }
    }
}
