using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

/// <summary>
/// the game object will jump to the current mouse position when the left mouse button is clicked
/// </summary>
public class Jumper : MonoBehaviour
{
    float colliderHalfWidth;
    float colliderHalfHeight;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = transform.localScale;

        scale.x *= 4;
        scale.y *= 4;

        transform.localScale = scale;

        BoxCollider2D bd2 = GetComponent<BoxCollider2D>();
        colliderHalfWidth = (bd2.size.x / 2) * 4;
        colliderHalfHeight = (bd2.size.y / 2) * 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pixelMousePosition = Input.mousePosition;

            pixelMousePosition.z = -Camera.main.transform.position.z;

            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(pixelMousePosition);

            Vector3 worldSizeVector = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Camera.main.pixelWidth,
                    Camera.main.pixelHeight,
                    worldMousePosition.z)
            );

            Debug.Log(worldSizeVector);
            Debug.Log(worldMousePosition);

            float minX = -worldSizeVector.x + colliderHalfWidth;
            float maxX = worldSizeVector.x - colliderHalfWidth;
            float minY = -worldSizeVector.y + colliderHalfHeight;
            float maxY = worldSizeVector.y - colliderHalfHeight;

            if (worldMousePosition.x <= minX)
            {
                worldMousePosition.x = minX;
            } else if (worldMousePosition.x >= maxX)
            {
                worldMousePosition.x = maxX;
            }

            if (worldMousePosition.y <= minY)
            {
                worldMousePosition.y = minY;
            } else if (worldMousePosition.y >= maxY)
            {
                worldMousePosition.y = maxY;
            }

            transform.position = worldMousePosition;
        }
    }
}
