using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlaneColor : MonoBehaviour
{
    public Renderer planeRenderer; // Reference to the plane's Renderer
    public Color newColor = Color.yellow; // Set the color you want

    void Start()
    {
        // Ensure the renderer is attached
        if (planeRenderer == null)
        {
            planeRenderer = GetComponent<Renderer>();
        }

        // Change the color of the material
        planeRenderer.material.color = newColor;
    }
}
