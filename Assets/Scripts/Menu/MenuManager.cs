using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame() {

        Debug.Log("Empezar el juego");
        SceneManager.LoadScene(1);
    
    }
    public void QuitGame() {

        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
