using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour{

    public GameObject mensajeCorrecto;
    public GameObject mensajeIncorrecto;
    void Start(){

        string resultado = PlayerPrefs.GetString("resultado", "perdido");

        if (resultado == "ganado"){

            mensajeCorrecto.SetActive(true);
        }
        else{

            mensajeIncorrecto.SetActive(true);
        }
    }
    public void MenuGame(){

        SceneManager.LoadScene(0);
    }
}