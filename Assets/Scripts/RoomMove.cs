using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChangeMax;
    public Vector2 cameraChaneMin;
    public Vector3 playerChange;
    public bool switchCompletely;
    private CameraMovement camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (switchCompletely)
            {
                camera.minPosition = cameraChaneMin;
                camera.maxPosition = cameraChangeMax;
            }
            else
            {
                camera.minPosition += cameraChaneMin;
                camera.maxPosition += cameraChangeMax;
                other.transform.position += playerChange;
            }

            other.transform.position += playerChange;
        }
    }
}
