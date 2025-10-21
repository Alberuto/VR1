using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Pregunta actual (elige uno: "ToonLink", "MajorasMask", "LinkHorse")
    public string currentQuestion = "MajorasMask";

    // Referencias a los modelos
    public GameObject toonZelda;
    public GameObject linkMajora;
    public GameObject korokHorse;

    // UI de feedback (opcional, puedes hacerlo luego)
    public GameObject correctMessage;
    public GameObject wrongMessage;

    private void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Método llamado por los ImageTargets al ser escaneados
    public void OnImageScanned(string imageName)
    {
        if (imageName == currentQuestion)
        {
            ShowCorrectModel(imageName);
            ShowFeedback(true);
        }
        else
        {
            ShowFeedback(false);
        }
    }

    private void ShowCorrectModel(string imageName)
    {
        switch (imageName)
        {
            case "ToonLink":
                toonZelda.SetActive(true);
                break;
            case "MajorasMask":
                linkMajora.SetActive(true);
                break;
            case "LinkHorse":
                korokHorse.SetActive(true);
                break;
        }
    }

    private void ShowFeedback(bool isCorrect)
    {
        if (correctMessage != null) correctMessage.SetActive(isCorrect);
        if (wrongMessage != null) wrongMessage.SetActive(!isCorrect);
    }
}