using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Parallax : MonoBehaviour
{
    public Vector2 parallaxSpeed;
    public Vector2 autoScrollSpeed;
    public float imageOverlap;
    public bool oneImage;
    private List<Transform> imageTransforms = new();
    private float imageDistance;
    private Transform cameraTransform;
    private Vector2 lastCamPos;
    Transform originalTransform;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalTransform = transform.GetChild(0);
        cameraTransform = Camera.main.transform;
        lastCamPos = cameraTransform.position;

        getImageDistance();
        if(!oneImage)
        {
            createSideImages();
        }
        fillImageList();
        
    }

    void getImageDistance()
    {
        imageDistance = originalTransform.GetComponent<SpriteRenderer>().bounds.size.x - imageOverlap;
    }

    void createSideImages()
    {
        Transform leftImage = Instantiate(originalTransform, transform);
        Transform rightImage = Instantiate(originalTransform, transform);

        
        leftImage.position = new Vector3(originalTransform.position.x - imageDistance, originalTransform.position.y, originalTransform.position.z);
        rightImage.position = new Vector3(originalTransform.position.x + imageDistance, originalTransform.position.y, originalTransform.position.z);
    }

    void fillImageList()
    {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            if (t != transform)
            {
                imageTransforms.Add(t);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        scrollImage();
        shiftImages();
    }

    void scrollImage()
    {
        //determine how far the camera moved from last frame
        Vector2 parallaxScroll = new Vector2((lastCamPos.x - cameraTransform.position.x) * parallaxSpeed.x, (lastCamPos.y - cameraTransform.position.y) * parallaxSpeed.y);

        foreach (Transform t in imageTransforms)
        {
            Vector3 curPos = t.position;

            float newXPos = curPos.x + autoScrollSpeed.x * Time.deltaTime - parallaxScroll.x;
            float newYPos = curPos.y + autoScrollSpeed.y * Time.deltaTime - parallaxScroll.y;

            t.position = new Vector3(newXPos, newYPos, curPos.z);
        }
        //cache the camera position for next frame
        lastCamPos = cameraTransform.position;

    }

    void shiftImages()
    {
        //images outside of these limits will be recycled
        float leftThreshold = cameraTransform.position.x - imageDistance * 1.6f;
        float rightThreshold = cameraTransform.position.x + imageDistance * 1.6f;

        foreach (Transform t in imageTransforms)
        {
            //image is completely left of view, move to right
            if (t.position.x < leftThreshold)
            {
                t.position = new Vector3(t.position.x + imageDistance * 3, t.position.y, t.position.z);
            }

            //image is completely right of the view, move to the left
            if (t.position.x > rightThreshold)
            {
                t.position = new Vector3(t.position.x - imageDistance * 3, t.position.y, t.position.z);
            }
        }
    }

}
