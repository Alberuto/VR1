using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour{

    public TextMeshProUGUI targetName;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public float tiempoRestante = 30f;
    public TextMeshProUGUI timerText;

    public AudioClip sonidoAcierto;
    public AudioClip sonidoError;
    private AudioSource audioSource;

    public string targetABuscar;
    public int vidas = 3;
    public int puntuacion = 0;
    private List<string> opciones = new List<string>() { "majorasmaskJose", "toonlink", "link-rider" };

    void Start() {
        audioSource = GetComponent<AudioSource>();
        generarSiguienteTarget();
        ActualizarUI();
    }
    void ActualizarUI() {

        if (vidas <= 0)
            GameOver();

        targetName.text = "Busca a: " + targetABuscar;
        scoreText.text = "Puntuacion: " + puntuacion;
        livesText.text = "Vidas: " + vidas;
    }
    public void OnTargetFound(string targetReconocido) {

        if (targetReconocido == targetABuscar){

            puntuacion++;
            audioSource.PlayOneShot(sonidoAcierto);

            if (puntuacion >= 3)
                GameOver();

            generarSiguienteTarget();
        }
        else {

            vidas--;
            audioSource.PlayOneShot(sonidoError);

            if (vidas == 0) 
                GameOver();
        }
        ActualizarUI();
    }
    void GameOver() {

        if (puntuacion >= 3)
            PlayerPrefs.SetString("resultado", "ganado");
        else
            PlayerPrefs.SetString("resultado", "perdido");

        PlayerPrefs.SetInt("puntuacionFinal", puntuacion);
        PlayerPrefs.SetInt("vidasRestantes", vidas);

        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
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
    void Update(){

        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0){

            vidas--;
            tiempoRestante = 30f;
        }
        timerText.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);
        ActualizarUI();
    }
    void Awake(){

        // Evita duplicados si esta escena se recarga o Vuforia crea otro
        if (FindObjectsOfType<GameController>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}