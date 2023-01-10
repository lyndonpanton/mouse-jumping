using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// the game object will jump to the current mouse position when the left mouse button is clicked
/// </summary>
public class Jumper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = transform.localScale;

        scale.x *= 4;
        scale.y *= 4;

        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pixelMousePosition = Input.mousePosition;

            pixelMousePosition.z = -Camera.main.transform.position.z;

            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(pixelMousePosition);

            transform.position = worldMousePosition;
        }
    }
}
