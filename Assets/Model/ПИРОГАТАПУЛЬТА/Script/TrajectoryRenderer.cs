using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRendererComponent;
    public Vector3 origin;
    public GameObject Gmorigin;
    public Vector3 speed;
    public GameObject Gmspeed;
    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
        origin = Gmorigin.transform.position;
        speed = Gmspeed.transform.position;
    }
    private void Update()
    {
        origin = Gmorigin.transform.position;
        speed = Gmspeed.transform.position;
        ShowTrajectory();
    }
    public void ShowTrajectory( )
    {
        Vector3[] points = new Vector3[100];
        lineRendererComponent.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

            if(points[i].y < 0)
            {
                lineRendererComponent.positionCount = i+1;
                break;
            }
        }

        lineRendererComponent.SetPositions(points);
    }
}
