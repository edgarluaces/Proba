using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuevo : MonoBehaviour
{
    private float velocitat;
    // Start is called before the first frame update
    void Start()
    {
        velocitat = 8;
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

        transform.position = novaPosicio;
    }
}
