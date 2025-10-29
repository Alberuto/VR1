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
    private List<string> opciones = new List<string>() { "majorasmaskJose", "toonlink", "link-rider" };

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

            if (puntuacion >= 3)
                GameOver();

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

        SceneManager.LoadScene(0);
    }
    void generarSiguienteTarget() {

        if (opciones.Count > 0){

            int posicionRandom = Random.Range(0, opciones.Count);
            targetABuscar = opciones[posicionRandom];
            opciones.RemoveAt(posicionRandom);
        }
        else {
            GameOver();
        }
    }
}