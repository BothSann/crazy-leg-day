using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform[] levelPart;
    [SerializeField] private Transform respawnPosition;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           Transform randomLevelPart = levelPart[Random.Range(0, levelPart.Length)];
           Transform newLevelPart = Instantiate(randomLevelPart, respawnPosition.position, transform.rotation, transform);
        }
    }
}
