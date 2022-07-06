using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpuFriend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D diger)
    {
        if (diger.CompareTag("tops"))
        {
            
            Destroy(diger.gameObject);
            
        }
    }
}
