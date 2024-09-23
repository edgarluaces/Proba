using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuevo : MonoBehaviour
{
    private float velocitat;
    private Vector2 minPantalla, maxPantalla;

    // Start is called before the first frame update
    void Start()
    {
        velocitat = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        minPantalla.x = minPantalla.x + 0.75f;
        maxPantalla.x = maxPantalla.x - 0.75f;
        minPantalla.y = minPantalla.y + 0.75f;
        maxPantalla.y = maxPantalla.y - 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");

        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);

        Vector2 direccioindicada = new Vector2(direccioIndicadaX, direccioIndicadaY);
        Vector2 novaPosicio = transform.position;
        novaPosicio = novaPosicio + direccioindicada * velocitat * Time.deltaTime;
        novaPosicio.x = Mathf.Clamp(novaPosicio.x, minPantalla.x, maxPantalla.x);
        novaPosicio.y = Mathf.Clamp(novaPosicio.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPosicio;
    }
}
