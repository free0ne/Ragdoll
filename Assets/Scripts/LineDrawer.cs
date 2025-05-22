using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private Transform target;

    private Transform bone;
    
    private void Awake()
    {
        // Устанавливаем количество точек линии (2 точки)
        lineRenderer.positionCount = 2;
    }

    public void EnableLine(Transform bone)
    {
        this.bone = bone;

        UpdatePositions();
        lineRenderer.enabled = true;
        enabled = true;
    }
    
    public void DisableLine()
    {
        lineRenderer.enabled = false;
        enabled = false;
    }
    
    private void Update()
    {
        UpdatePositions();
    }

    private void UpdatePositions()
    {
        // Устанавливаем позиции
        lineRenderer.SetPosition(0, target.position);
        lineRenderer.SetPosition(1, bone.position);
    }
}
