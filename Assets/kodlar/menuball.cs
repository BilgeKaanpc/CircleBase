using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class menuball : MonoBehaviour
{

    public GameObject top;
    public GameObject where;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         int sayim = Random.Range(4, 100);
        if (sayim == 5)
        {
          
        Instantiate(top, where.transform.position, where.transform.rotation);

            
        }
    }
     void FixedUpdate()
    {

       
       
    }
}
