using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil_Putin : MonoBehaviour
{
    [SerializeField]
    private float _vel;
    private Vector2 maxPantalla;
    
    // Start is called before the first frame update
    void Start()
    {
        _vel = 10f;
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual = posActual + new Vector2(0, 1) * _vel * Time.deltaTime;
        transform.position = posActual;

        if(transform.position.y > maxPantalla.y)
        {
            Destroy(gameObject);
        }
    }
}
