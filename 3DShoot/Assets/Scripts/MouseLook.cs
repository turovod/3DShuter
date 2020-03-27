using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9f;
    public float sensitivityVert = 9f;

    private float minimumVert = -45;
    private float maximumVert = 45;

    private float _rotationX;
    private float _rotationY;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true; // Предотвращение вращения игрока при столкновениях
        }
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;

            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            _rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else if(axes == RotationAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            _rotationY += Input.GetAxis("Mouse X") * sensitivityHor;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
            
        }
        
    }
}
