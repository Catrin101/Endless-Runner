using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int FuerzaSalto,VelocidadMov;
    bool enElPiso=false;

    void Start(){
        
    }

    void Update(){
        if(Input.GetKeyDown("space") && enElPiso){
            enElPiso=false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(
                0,FuerzaSalto));
        }
        this.GetComponent<Rigidbody2D>().velocity=new Vector2(
            VelocidadMov,this.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collicion) {
        enElPiso=true;
        if(collicion.collider.gameObject.tag=="Obstaculo"){
            GameObject.Destroy(this.gameObject);
        }
    }
}
