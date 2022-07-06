using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    
    public GameObject sag;
    public GameObject sol;
    public GameObject solum;
    public GameObject sagim;

    
    void OnTriggerEnter2D(Collider2D diger)
    {
        if (diger.CompareTag("tops"))
        {
            sag.gameObject.SetActive(false);
            sol.gameObject.SetActive(false);
            sagim.gameObject.SetActive(true);
            solum.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D diger)
    {
        if (diger.CompareTag("tops"))
        {
            sag.gameObject.SetActive(true);
            sol.gameObject.SetActive(true);
            sagim.gameObject.SetActive(false);
            solum.gameObject.SetActive(false);
        }
    }


}
