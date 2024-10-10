using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nuevo : MonoBehaviour
{
    private float velocitat;
    private Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefabProjectil;
    [SerializeField] private GameObject prefabExplosio;
    private int vidajugador;
    [SerializeField] private TMPro.TextMeshProUGUI uiVidesJugador;

    // Start is called before the first frame update
    void Start()
    {
        dadesglobals.reiniciarpunts();
        vidajugador = 3;
        velocitat = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        
        float midameitatImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float midameitatImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        //bordes para que la nave no salga
        minPantalla.x += midameitatImatgeX;
        maxPantalla.x -= midameitatImatgeX;
        minPantalla.y += midameitatImatgeY;
        maxPantalla.y -= midameitatImatgeY;
    }

    // Update is called once per frame
    void Update()
    {
        movimentNau();
        DisparaProjectil();
        
    }
    private void movimentNau()
    {
        //movimiento izquierda y derecha
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

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            vidajugador--;
            uiVidesJugador.text = "Vides: " + vidajugador.ToString();
            if(vidajugador <= 0)
            {
                GameObject explosio = Instantiate(prefabExplosio);
                explosio.transform.position = transform.position;
                SceneManager.LoadScene("pantallaresultats");
                Destroy(gameObject);

            }
            
        }
        
    }




    private void DisparaProjectil()
    {
        if(Input.GetKeyDown("space"))
        {
            GameObject projectil = Instantiate(prefabProjectil);
            projectil.transform.position = transform.position;
        }
    }
}
