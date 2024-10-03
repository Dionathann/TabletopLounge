using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public float flipSpeed = 5f;  // Speed of the flip
    private bool isFlipping = false;
    private Quaternion originalRotation;
    private Quaternion flippedRotation;
    private RectTransform imageRectTransform;

    void Start()
    {
        // Get the RectTransform component of the UI Image
        imageRectTransform = GetComponent<RectTransform>();

        // Store the original rotation
        originalRotation = imageRectTransform.rotation;

        // Set the flipped rotation (180 degrees on the Y axis)
        flippedRotation = Quaternion.Euler(imageRectTransform.rotation.eulerAngles.x, imageRectTransform.rotation.eulerAngles.y + 180, imageRectTransform.rotation.eulerAngles.z);
    }

    public void Flipping()
    {

    }

    void Update()
    {
        // Check if the player is holding down the screen (using mouse or touch)
        if (Input.GetMouseButton(0))
        {
            isFlipping = true;
        }
        else
        {
            isFlipping = false;
        }

        // Flip the image
        if (isFlipping)
        {
            // Rotate towards the flipped rotation
            imageRectTransform.rotation = Quaternion.Lerp(imageRectTransform.rotation, flippedRotation, Time.deltaTime * flipSpeed);
        }
        else
        {
            // Rotate back to the original rotation
            imageRectTransform.rotation = Quaternion.Lerp(imageRectTransform.rotation, originalRotation, Time.deltaTime * flipSpeed);
        }
    }

}
