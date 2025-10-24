using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject camera;
    [SerializeField] private float parallaxEffect;
    private float length;
    private float xPos;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = (camera.transform.position.x * (1 - parallaxEffect));
        float distanceToMove = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(xPos + distanceToMove, transform.position.y);

        if (distanceMoved > xPos + length)
        {
            xPos += length;
        }
        else if (distanceMoved < xPos - length)
        {
            xPos -= length; 
        }
    }
}
