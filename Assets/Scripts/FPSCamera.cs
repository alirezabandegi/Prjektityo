using UnityEngine;
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Transform))]
public class FPSCamera : MonoBehaviour
{
    [SerializeField] Soldier target;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector2 rotationOffset;
    Transform _targetTransform, _spineTransform;

    Transform _camTransform;
    Camera _cam;

    [SerializeField] float cameraSensitivity;

    Vector2 _rotation = Vector2.zero;
    const float YRotationLimit = 88;

    void Start()
    {
        _camTransform = GetComponent<Transform>();
        _cam = GetComponent<Camera>();
        _targetTransform = target.gameObject.GetComponent<Transform>();
        _spineTransform = target.spine;
    }
    
    void LateUpdate()
    {
        Vector3 difference = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _targetTransform.rotation = Quaternion.Euler(0,0, rotationZ);

        //mouse movement
        float verticalMovement = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSensitivity;
        float horizontalMovement = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSensitivity;
        _camTransform.rotation *= Quaternion.Euler(verticalMovement, horizontalMovement, 0);
        
        //mouse input as quaternion rotations
        _rotation.x += Input.GetAxis("Mouse X") * cameraSensitivity;
        _rotation.y += Input.GetAxis("Mouse Y") * cameraSensitivity;
        _rotation.y = Mathf.Clamp(_rotation.y, -YRotationLimit, YRotationLimit); //limit to prevent flipping
        var xQuat = Quaternion.AngleAxis(_rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(_rotation.y, Vector3.left);

        //apply rotationOffset to same rotation (for camera)
        var camXQuat =  Quaternion.AngleAxis(_rotation.x + rotationOffset.x, Vector3.up);
        var camYQuat =  Quaternion.AngleAxis(_rotation.y + rotationOffset.y, Vector3.left);

        //camera rotation
        _camTransform.rotation = camXQuat * camYQuat;
        _camTransform.position = _targetTransform.position + _camTransform.TransformDirection(offset);
        
        //character rotation
        _targetTransform.rotation = xQuat;
    }
}