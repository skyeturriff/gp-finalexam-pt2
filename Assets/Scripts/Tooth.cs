using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tooth : MonoBehaviour 
{
    private ToothManager _toothManager;
    private Material _toothMaterial;
    public Material toothMaterial 
    {
        get 
        {
            if(_toothMaterial == null) 
            {
                Renderer renderer = GetComponent<Renderer>();
                _toothMaterial = renderer.material;
            }
            return _toothMaterial;
        }
    }

    void Start() 
    {
        _toothManager = GetComponentInParent<ToothManager>();
        if(_toothManager == null) 
        {
            throw new System.Exception("ToothManager not found amoung Tooth's parents.");
        }
    }

    public void OnDestroy() 
    {
        _toothManager.RemoveTooth(gameObject);
    }
}
