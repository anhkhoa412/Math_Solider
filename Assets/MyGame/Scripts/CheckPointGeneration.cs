using UnityEngine;

public class CheckPointGeneration : MonoBehaviour
{
   
    public GameObject checkPointPrefab; // Corrected variable name
    public Transform player;
    public float segmentLength = 10.0f; // Length of each road segment

    private Transform lastSegmentEnd;

   
    private void Start()
    {
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
                }
        lastSegmentEnd = transform;
    
    }

    private void Update()
    {
      
            // Check if the player has moved past the last generated segment
            if (player.position.z >= lastSegmentEnd.position.z - 10)
            {
                GenerateCheckSegment();
            }
        
    }

    private void GenerateCheckSegment()
    {
        // Instantiate a new road segment at the end of the last segment

        GameObject newSegment = Instantiate(checkPointPrefab, lastSegmentEnd.position + Vector3.forward * segmentLength, Quaternion.identity);

        lastSegmentEnd = newSegment.transform; // Update lastSegmentEnd to the new segment's end
    }

}
