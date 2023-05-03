using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPointInSectorCircle : MonoBehaviour
{
    [SerializeField] private float radius, angleInRad;
    [SerializeField] private GameObject points;

    private Vector3 rightArm;
    private Vector3 leftArm;
    private Vector3 upArm;
    private Vector3 downArm;

    private List<Transform> pointsChildren = new List<Transform>();
    private SpawnRandomlyInASphere spawnScript;

    private void Start()
    {
        spawnScript = points.GetComponent<SpawnRandomlyInASphere>();
        foreach (Transform t in points.transform)
        {
            pointsChildren.Add(t);
        }
    }

    private void Update()
    {
        findAllArmSectors(radius, angleInRad);

        if (spawnScript.listUpdated == true)
        {
            spawnScript.listUpdated = false;
            pointsChildren.Clear();

            pointsChildren.AddRange(spawnScript.spawnList);
        }

        for (int i = 0; i < pointsChildren.Count; i++)
        {
            Transform t = pointsChildren[i];
            if (isInsideSector(t.position, transform.position, rightArm, leftArm, downArm, upArm)
                    && Vector3.Distance(transform.position, t.position) < radius)
            {
                t.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                t.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }
    }


    private void findAllArmSectors(float radius, float angleinRad)
    {
        rightArm = new Vector3(radius * Mathf.Cos(angleinRad), radius * Mathf.Sin(angleinRad), 0f);
        leftArm = new Vector3(-radius * Mathf.Cos(angleinRad), radius * Mathf.Sin(angleinRad), 0f);

        upArm = new Vector3(0f, radius * Mathf.Sin(angleinRad), radius * Mathf.Cos(angleinRad));
        downArm = new Vector3(0f, radius * Mathf.Sin(angleinRad), -radius * Mathf.Cos(angleinRad));
    }

    private bool areClockwise(Vector2 vect1, Vector2 vect2)
    {
        // if the two vector are positive then they are clockwise
        return (-vect1.x * vect2.y) + (vect1.y * vect2.x) > 0;
    }

    private bool areClockwiseZAxis(Vector3 vect1, Vector3 vect2)
    {
        // if the two vector are positive then they are clockwise
        return (-vect1.z * vect2.y) + (vect1.y * vect2.z) < 0;
    }

    private bool isInsideSector(Vector3 point, Vector3 center, Vector3 sectorStart, Vector3 sectorEnd, Vector3 sectorStartZAxis, Vector3 sectorEndZAxis)
    {
        Vector3 relPoint = new Vector3(point.x - center.x, point.y - center.y, point.z - center.z);

        return (!areClockwise(sectorStart, relPoint) && areClockwise(sectorEnd, relPoint)) &&
               (!areClockwiseZAxis(sectorStartZAxis, relPoint) && areClockwiseZAxis(sectorEndZAxis, relPoint));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Draw the arc
        findAllArmSectors(radius, angleInRad);
        Gizmos.DrawLine(transform.position, leftArm);
        Gizmos.DrawLine(transform.position, rightArm);
        Gizmos.DrawLine(transform.position, upArm);
        Gizmos.DrawLine(transform.position, downArm);

        // Draw connecting lines
        Gizmos.DrawLine(downArm, leftArm);
        Gizmos.DrawLine(downArm, rightArm);
        Gizmos.DrawLine(rightArm, upArm);
        Gizmos.DrawLine(upArm, leftArm);

    }
}
