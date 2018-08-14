using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticiesDebug : MonoBehaviour
{

    MeshFilter filter;
	void Start ()
    {
        filter = GetComponent<MeshFilter>();
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        foreach (Vector3 vert in filter.mesh.vertices)
        {
            Gizmos.DrawWireSphere(transform.TransformPoint(vert), .05f);          
        }
    }
}
