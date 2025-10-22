using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class GameController : MonoBehaviour{

    public TextMeshProUGUI targetName;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public string targetABuscar;
    public int vidas = 3;
    public int puntuacion = 0;
    public List<string> opciones = new List<string>() { "majoras", "toon", "horse" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
        //[] majoras, toon, linkhorse

      //  targetABuscar = "Link de" + "Majoras";
        generarSiguienteTarget();

        ActualizarUI();
    }

    void ActualizarUI() { 
    
        targetName.text = "Busca a: " + targetABuscar;

        scoreText.text = "Puntuacion: " + puntuacion;

        livesText.text = "Vidas: " + vidas;
    
    }
    public void OnTargetFound(string targetReconocido) {

        //mostrar el target reconocido y depuracion
        
        scoreText.text = targetReconocido;

        if (targetReconocido == targetABuscar){

            ActualizarPuntuacion();
            generarSiguienteTarget();

        }
        else { 
            
            ActualizarVidas();
            if (vidas == 0) {
                //gAmE OvEr
                GameOver();
            }
        
        }

        ActualizarUI();
    }
    void GameOver() { 
        


        
        
    }
    void generarSiguienteTarget() {
        int posicionRandom = Random.Range(0, opciones.Count);
        targetABuscar = opciones[posicionRandom];
    
    }
    public void ActualizarVidas() {

        vidas--;
    }
    public void ActualizarPuntuacion() {
        
        puntuacion++;
        
    }
}