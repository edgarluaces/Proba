using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalpunts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Punts: " + dadesglobals.punts;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
