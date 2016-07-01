using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LineScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private NavMeshAgent agent;
	// Use this for initialization
	void Start ()
    {
        gameObject.tag = "line";
        lineRenderer = GetComponent<LineRenderer>();
        agent = transform.parent.GetComponent<NavMeshAgent>();

        lineRenderer.SetColors(Color.white, Color.white);
        lineRenderer.SetWidth(0.1f, 0.1f);
        lineRenderer.material.color = Color.white;
        lineRenderer.material.shader = Shader.Find("Sprites/Default");

        StartCoroutine("DrawPath");
	}

    IEnumerator DrawPath() {
        int vertexCount = 0;

        while (true) {
            while (agent.pathPending) {
                yield return null;
            }

            while (agent.remainingDistance > agent.stoppingDistance) {
                int pathCorners = agent.path.corners.Length;
                if (vertexCount != pathCorners && pathCorners > 2) { // not sure if we should draw 1 corner paths
                    vertexCount = pathCorners;

                    lineRenderer.SetVertexCount(vertexCount);
                    for (var i = 1; i < vertexCount; i++) {
                        lineRenderer.SetPosition(i, agent.path.corners[i]);
                    }

                    if (!gameObject.activeSelf) {
                        gameObject.SetActive(true);
                    }
                }
                yield return null;
            }

            yield return null;
        }
    }
}
