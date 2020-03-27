using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] GameObject bulet;
    private Camera _camera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2.156f, _camera.pixelHeight / 2, 0);

            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    IEnumerator SphereIndicator(Vector3 pos)
    {
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject sphere = GameObject.Instantiate(bulet);

        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
