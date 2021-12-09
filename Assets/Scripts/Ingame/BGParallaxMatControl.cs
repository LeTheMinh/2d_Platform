using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParallaxMatControl : MonoBehaviour
{
    public Material[] backgrounds;             // Array of all the backgrounds to be parallaxed.
    public float parallaxScale;                 // The proportion of the camera's movement to move the backgrounds by.
    public float parallaxReductionFactor;       // How much less each successive layer should parallax.
    public float smoothing;                     // How smooth the parallax effect should be.


    private Transform cam;                      // Shorter reference to the main camera's transform.
    private Vector3 previousCamPos;             // The postion of the camera in the previous frame.
    private Transform trans;                                           // Start is called before the first frame update
    private Vector3 offsetCam;
    void Awake()
    {
        // Setting up the reference shortcut.
        cam = Camera.main.transform;
        trans = transform;
        offsetCam = trans.position - cam.position;
    }


    void Start()
    {
        // The 'previous frame' had the current frame's camera position.
        previousCamPos = cam.position;
    }

    private void Update()
    {
        // trans.position = Vector3.Lerp(trans.position, cam.position + offsetCam, Time.deltaTime * 10);
        // trans.position = Vector3.MoveTowards(trans.position, cam.position + offsetCam, Time.deltaTime * 2);
        // The parallax is the opposite of the camera movement since the previous frame multiplied by the scale.
        
        float parallax = (cam.position.x - previousCamPos.x) * parallaxScale;

        // For each successive background...
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector2 offset = backgrounds[i].GetTextureOffset("_MainTex");
            // ... set a target x position which is their current position plus the parallax multiplied by the reduction.
            float backgroundTargetPosX = offset.x + parallax * (i * parallaxReductionFactor + 1);

            // Create a target position which is the background's current position but with it's target x position.
            Vector2 backgroundTargetPos = new Vector2(backgroundTargetPosX, 0);

            // Lerp the background's position between itself and it's target position.
            offset = Vector2.Lerp(offset, backgroundTargetPos, smoothing * Time.deltaTime);
            backgrounds[i].SetTextureOffset("_MainTex", offset);
        }
        // Set the previousCamPos to the camera's position at the end of this frame.
        previousCamPos = cam.position;
        Vector3 pos = trans.position;
        pos.x = Mathf.Lerp(pos.x, (cam.position + offsetCam).x, Time.deltaTime * 20);
        trans.position = pos;
    }
}
