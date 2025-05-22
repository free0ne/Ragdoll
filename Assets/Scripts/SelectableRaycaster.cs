using UnityEngine;

public class SelectableRaycaster : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TargetPointer targetPointer;
    [SerializeField] private LineDrawer lineDrawer;

    private (bool exists, Selectable selectable) selectedUnit = (false, null);

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartRaycast();
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            KeepRaycasting();
            return;
        }
        
        if (Input.GetMouseButtonUp(0))
            Cancel();
    }

    private void StartRaycast()
    {
        EnablePointer();
        
        Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] hitColliders = Physics2D.OverlapPointAll(worldPoint);

        foreach (var col in hitColliders)
        {
            Debug.Log("Клик по: " + col.gameObject.name);
                
            if (col.TryGetComponent<Selectable>(out var selectable))
            {
                StartDragging(selectable);
                break;
            }
            else
            {
                Debug.Log($"No selectable found for {col.gameObject.name}");
            }
        }
    }

    private void StartDragging(Selectable selectable)
    {
        SelectSelectable(selectable);
        lineDrawer.EnableLine(selectable.GetTransform());
    }

    private void KeepRaycasting()
    {
        SetPointerPosition();
    }

    private void EnablePointer()
    {
        targetPointer.gameObject.SetActive(true);
        SetPointerPosition();
    }

    private void SetPointerPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5;
        
        targetPointer.SetPosition(mainCamera.ScreenToWorldPoint(mousePos));
    }
    
    private void Cancel()
    {
        if (selectedUnit.exists)
        {
            DeselectSelectable();
            lineDrawer.DisableLine();
        }
                
        targetPointer.gameObject.SetActive(false);
    }

    private void SelectSelectable(Selectable selectable)
    {
        selectedUnit = (true, selectable);
        selectable.OnSelected(targetPointer.GetRigidbody());
    }
    
    private void DeselectSelectable()
    {
        selectedUnit.selectable.OnDeselected();
        selectedUnit = (false, null);
    }
}
