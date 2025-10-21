using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform[] levelPart;
    [SerializeField] private Vector3 nextLevelPartPosition;
    [SerializeField] private float distanceToDelete;
    [SerializeField] private float distanceToGenerate;
    [SerializeField] private Transform player;


    // Update is called once per frame
    void Update()
    {
        DeletePlatform();
        GeneratePlatform();
    }

    private void GeneratePlatform()
    {
        while (Vector2.Distance(player.transform.position, nextLevelPartPosition) < distanceToGenerate)
        {
            Transform randomLevelPart = levelPart[Random.Range(0, levelPart.Length)];

            Vector2 newPosition = new Vector2(nextLevelPartPosition.x - randomLevelPart.Find("StartPoint").position.x, 0);

            Transform newLevelPart = Instantiate(randomLevelPart, newPosition, transform.rotation, transform);

            nextLevelPartPosition = newLevelPart.Find("EndPoint").position;
        }
    }

    private void DeletePlatform()
    {
        if(transform.childCount > 0) 
        {
            Transform partToDelete = transform.GetChild(0);

            if(Vector2.Distance(player.transform.position, partToDelete.position) > distanceToDelete)
            {
                Destroy(partToDelete.gameObject);
            }
        }
    }
}   
