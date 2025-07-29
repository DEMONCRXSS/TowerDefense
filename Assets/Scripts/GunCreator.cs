using UnityEngine;

public class GunCreator : MonoBehaviour
{
    [SerializeField]
    private float _raycastDitance = 100f;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private string _floorTag = "Floor";
    private bool _gunPlaced = false;
    private Transform _gun;
    private void Update()
    {
        
    }
}
