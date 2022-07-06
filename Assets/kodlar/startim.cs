using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class startim : MonoBehaviour
{

    public Button playim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gameStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator gameStart()
    {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(1);
    }

    
}
