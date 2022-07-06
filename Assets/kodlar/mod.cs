using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod : MonoBehaviour
{

    public GameObject cember;
    public int hiz;
    void FixedUpdate()
    {
        cember.transform.Rotate(0, 0, hiz * Time.deltaTime);


       
    }

   

}
