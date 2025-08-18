using UnityEngine;

public class InfernoTower : MonoBehaviour
{
    [SerializeField] Transform towerHead; // The part of the tower that rotates and shoots
    [SerializeField] Transform TargetPlayer;

    private void Update()
    {
        towerHead.LookAt(TargetPlayer); // Make the tower head look at the camera
    }
}
