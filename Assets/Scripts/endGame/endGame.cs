using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour{

    public GameObject mensajeCorrecto;
    public GameObject mensajeIncorrecto;

    public TextMeshProUGUI resultados;

    void Start(){

        string resultado = PlayerPrefs.GetString("resultado", "perdido");
        int puntos = PlayerPrefs.GetInt("puntuacionFinal");
        int vidas = PlayerPrefs.GetInt("vidasRestantes");

        if (resultado == "ganado")
            mensajeCorrecto.SetActive(true);
        else
            mensajeIncorrecto.SetActive(true);

        string result = "el jugador ha terminado con: " + vidas + " vidas y con :" + puntos + " puntos";
        resultados.text = result;
    }
    public void MenuGame(){
        SceneManager.LoadScene(0);
    }
}