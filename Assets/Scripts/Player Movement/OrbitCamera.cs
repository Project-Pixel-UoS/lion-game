using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    [Header("Camera Settings")]
    public Transform pivotPoint;
    //Camera Sensitivity
    public float rotationSpeed = 0.5f;
    public bool invertControls = true;

    private Vector3 lastInputPosition;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastInputPosition = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 currentInputPos = Input.mousePosition;
            float xChange = currentInputPos.x - lastInputPosition.x;
            
            float dir = 1f;
            if (invertControls) dir = -1f;
            
            transform.RotateAround(pivotPoint.position, Vector3.forward, xChange * rotationSpeed * Time.deltaTime * dir);
            
        }
        
    }
    
}
