using UnityEngine;
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float _zoomModifierSpeed = 0.1f;
    private float _zoomSpeedPC = 100f; // Speed at which the camera zooms
    private float _minZoom = 2f;     // Minimum orthographic size of the camera
    private float _maxZoom = 12f;    // Maximum orthographic size of the camera

    private float _touchesPrevPosDifference;
    private float _touchesCurPosDifference;
    private float _zoomModifier;

    private Vector2 _firstTouchPrevPos;
    private Vector2 _secondTouchPrevPos;

    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {

#if UNITY_EDITOR
        // Check for zoom input in the editor using the mouse scroll wheel
        PCZoom();
#elif UNITY_ANDROID
         MobileZoom();
#endif


    }
    private void MobileZoom()
    {
        if(Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            _firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            _secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

            _touchesPrevPosDifference = (_firstTouchPrevPos - _secondTouchPrevPos).magnitude;
            _touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

            _zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * _zoomModifierSpeed;

            if (_touchesPrevPosDifference > _touchesCurPosDifference)
            {
                _camera.orthographicSize += _zoomModifier;
            }
            if (_touchesPrevPosDifference < _touchesCurPosDifference)
            {
                _camera.orthographicSize -= _zoomModifier;
            }
        }

        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minZoom, _maxZoom);
    }
    private void PCZoom()
    {
        float zoomAmount = -Input.GetAxis("Mouse ScrollWheel");
        // Adjust the orthographic size based on the zoom amount
        Camera.main.orthographicSize += zoomAmount * _zoomSpeedPC * Time.deltaTime;

        // Clamp the orthographic size within the defined range
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, _minZoom, _maxZoom);
    }
}
