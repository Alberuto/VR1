using UnityEngine;
using Vuforia;

public class ImageTargetHandler : MonoBehaviour{

    private ObserverBehaviour observerBehaviour;
    private GameController gameController;

    void Start(){

        observerBehaviour = GetComponent<ObserverBehaviour>();
        gameController = FindFirstObjectByType<GameController>();

        if (observerBehaviour) {

            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;        
        }
    }
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status){

        if (status.Status == Status.TRACKED){

            gameController.OnTargetFound(behaviour.TargetName);
        }
    }
    void Update(){
        
    }
}