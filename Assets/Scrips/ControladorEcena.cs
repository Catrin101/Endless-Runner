using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorEcena : MonoBehaviour
{
    public GameObject jugador;
    public Camera camaraJuego;
    public GameObject[] BlaquePrefab;
    public float PunteroJuego,LugarSeguroGenerasion=12;
    public Text TextoJuego;
    public bool perdiste;

    void Start()
    {
        PunteroJuego=-7;
        perdiste = false;
    }

    void Update()
    {
        if(jugador!=null){
            camaraJuego.transform.position=new Vector3(
                jugador.transform.position.x,
                camaraJuego.transform.position.y,
                camaraJuego.transform.position.z);  
                TextoJuego.text="Puntaje: "+Mathf.Floor(jugador.transform.position.x);
        }else{
            if(!perdiste){
                perdiste=true;
                TextoJuego.text+="\nSe termino el juego! \nPresione R para volver a empesar";
            }
            if(perdiste){
                if(Input.GetKeyDown("r")){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        while(jugador!=null && PunteroJuego<jugador.transform.position.x+LugarSeguroGenerasion){
            int indiceBloque = Random.Range(0,BlaquePrefab.Length-1);
            if(PunteroJuego<0){
                indiceBloque=5;
            }
            GameObject ObjetoBloque = Instantiate(BlaquePrefab[indiceBloque]);
            ObjetoBloque.transform.SetParent(this.transform);
            Bloque bloque = ObjetoBloque.GetComponent<Bloque>();
            ObjetoBloque.transform.position = new Vector2(PunteroJuego+bloque.tamano/2,0);
            PunteroJuego+=bloque.tamano;
        }
    }
}
