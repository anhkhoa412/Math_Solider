using UnityEngine;
using System.Collections.Generic;

public class InfiniteRoadGenerator : MonoBehaviour
{
    public GameObject roadSegmentPrefab;
    public GameObject checkPointPrefab;
    public Transform player;
    public float segmentLength = 10.0f;
    public int maxVisibleSegments = 5;

    private List<Transform> roadSegments = new List<Transform>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GenerateInitialSegments();
    }

    private void GenerateInitialSegments()
    {
        for (int i = 0; i < maxVisibleSegments; i++)
        {
            GenerateRoadSegment();
        }
    }

    private void GenerateRoadSegment()
    {
        GameObject newSegment = Instantiate(roadSegmentPrefab, transform.position, Quaternion.identity);
        roadSegments.Add(newSegment.transform);

        if (roadSegments.Count > maxVisibleSegments)
        {
            Destroy(roadSegments[0].gameObject);
            roadSegments.RemoveAt(0);
        }
        Instantiate(checkPointPrefab, transform.position + Vector3.forward * (segmentLength - 1), Quaternion.identity);


        transform.position += Vector3.forward * segmentLength;
    }

    private void Update()
    {
        if (player.position.z >= roadSegments[0].position.z)
        {
            GenerateRoadSegment();
        }
    }
}
