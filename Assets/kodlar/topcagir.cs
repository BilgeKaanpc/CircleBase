using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topcagir : MonoBehaviour
{

    Rigidbody2D fizik;
    public float Hizim;

    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
       
        fizik.AddForce(Vector2.up * Hizim);
    }

}
