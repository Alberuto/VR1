using UnityEngine;
using Vuforia;

public class ImageTargetResponder : MonoBehaviour{

    public string imageID; // Debe ser "ToonLink", "MajorasMask", "LinkHorse"
    private ObserverBehaviour observerBehaviour;

    void Start(){

        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null){
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }
    private void OnDestroy(){

        if (observerBehaviour != null){
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status){

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED){
            Debug.Log("Escaneado: " + imageID);
            GameManager.Instance.OnImageScanned(imageID);
        }
    }
}