using UnityEngine;

public class Infection : MonoBehaviour 
{
    public Color infectedColor = Color.white;
    private Tooth _tooth;
    private Color _oldColor = Color.white;
    private float _elapsedTime = 0.0f;

    void Start() 
    {
        FindTooth();
    }

    void FindTooth() 
    {
        _tooth = GetComponent<Tooth>();
        if(_tooth == null) 
        {
            throw new System.Exception("Infection not added to a tooth.");
        }
    }

    void Update() 
    {
        if(_elapsedTime < 1.0f) 
        {
            _elapsedTime += Time.deltaTime;
            _tooth.toothMaterial.color = Color.Lerp(_oldColor, infectedColor, _elapsedTime);
        }
    }

    public void OnCollisionEnter(Collision collision) 
    {
        GameObject otherGO = collision.collider.gameObject;
        if(otherGO.tag == "Sweets") 
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;

            // Propogate velocity.
            Rigidbody otherGORigidbody = otherGO.GetComponent<Rigidbody>();
            rigidbody.velocity = otherGORigidbody.velocity;
            rigidbody.angularVelocity = otherGORigidbody.angularVelocity;

            // Destroy the game object after 2 seconds.
            Destroy(this /**/, 2.0f);
        }
    }
}
