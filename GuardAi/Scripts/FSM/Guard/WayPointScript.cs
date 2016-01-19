using UnityEngine;
using System.Collections;

public class WayPointScript : MonoBehaviour
{
	private float height = 1.5f;
    private float pinHeadSize = 0.5f;
    private float markerSize = 0.2f;

    public Transform[] m_Neighbours;
    public Transform m_NextWayPoint;
    public int wayPtNo;

    void OnDrawGizmos()
    {
        if (tag == "path_01")
        {
            Gizmos.color = Color.blue;
        }

        else if (tag == "path_02")
        {
            Gizmos.color = Color.yellow;
        }

        Gizmos.DrawCube(transform.position + Vector3.up * height, new Vector3(pinHeadSize, pinHeadSize, pinHeadSize));
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * (height - pinHeadSize * 0.5f));
        Gizmos.DrawLine(transform.position - Vector3.right * markerSize, transform.position - Vector3.right * markerSize);
        Gizmos.DrawCube(transform.position, new Vector3(pinHeadSize, 0.1f, pinHeadSize));

        foreach (Transform neighbour in m_Neighbours)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, neighbour.position);
        }
    }
}
