using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour{

    public TextMeshProUGUI targetName;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public string targetABuscar;
    public int vidas = 3;
    public int puntuacion = 0;
    public List<string> opciones = new List<string>() { "majorasmaskJose", "toonlink", "link-rider" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        generarSiguienteTarget();
        ActualizarUI();
    }
    void ActualizarUI() { 
    
        targetName.text = "Busca a: " + targetABuscar;
        scoreText.text = "Puntuacion: " + puntuacion;
        livesText.text = "Vidas: " + vidas;
    }
    public void OnTargetFound(string targetReconocido) {

        if (targetReconocido == targetABuscar){

            puntuacion++;
            generarSiguienteTarget();
        }
        else {

            vidas--;
            if (vidas == 0) 
                GameOver();
        }
        ActualizarUI();
    }
    void GameOver() {

        Debug.Log("Fin del juego");
        SceneManager.LoadScene(0);
    }
    void generarSiguienteTarget() {

        int posicionRandom = Random.Range(0, opciones.Count);
        targetABuscar = opciones[posicionRandom];
    }
}