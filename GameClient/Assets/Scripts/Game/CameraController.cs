using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private LocalPlayerMovement _player;
    [Header("Movement")]
    [SerializeField]
    private float _zoomSpeed = 5f;
    [SerializeField]
    private float _zoomIncrement = 5f;
    [SerializeField]
    private float _rotationSpeed = 3f;
    [Header("Distance")]
    [SerializeField]
    private float _initialDistance = 5f;
    [SerializeField]
    private float _minDistance = 0;
    [SerializeField]
    private float _maxDistance = 7;
    [Header("Physics")]
    [SerializeField]
    private LayerMask _collisionLayers;
    private Vector3 _offset;
    private float _currentDistance;
    private float _xRotation = 0f;
    private float _yRotation = 0f;
    private float _desiredDistance;

    private void Start() {
        _offset = transform.position - _target.position;
        _currentDistance = _initialDistance;
        _desiredDistance = _initialDistance;
    }

    private void LateUpdate() {
        if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            _desiredDistance -= scroll * _zoomIncrement;
            _desiredDistance = Mathf.Clamp(_desiredDistance, _minDistance, _maxDistance);

            if (Input.GetMouseButton(0)) {
                _xRotation += Input.GetAxis("Mouse X") * _rotationSpeed;
                _yRotation -= Input.GetAxis("Mouse Y") * _rotationSpeed;
                _yRotation = Mathf.Clamp(_yRotation, -60f, 60f);
            }
            if (Input.GetMouseButton(1)) {
                _xRotation += Input.GetAxis("Mouse X") * _rotationSpeed;
                _yRotation -= Input.GetAxis("Mouse Y") * _rotationSpeed;
                _yRotation = Mathf.Clamp(_yRotation, -60f, 60f);
                _player.transform.rotation = Quaternion.Euler(0f, _xRotation, 0f);
            }
        }

        _currentDistance = Mathf.Lerp(_currentDistance, _desiredDistance, _zoomSpeed * Time.deltaTime);

        Quaternion rotation = Quaternion.Euler(_yRotation, _xRotation, 0f);
        Vector3 desiredPosition = _target.position + rotation * _offset * _currentDistance;

        if (Physics.Linecast(_target.position, desiredPosition, out RaycastHit hit, _collisionLayers))
            desiredPosition = hit.point + Vector3.up * .1f;

        transform.SetPositionAndRotation(desiredPosition, rotation);
    }
}