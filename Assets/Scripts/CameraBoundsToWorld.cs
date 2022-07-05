using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CornerName
{
    LeftBottom,
    LeftUpper,
    RightUpper,
    RightBottom
}
public class CameraBoundsToWorld : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private CornerName[] _corners;

    private Vector2[] _cornersPosition ;

    public static Dictionary<CornerName, Vector3> WorldPositionCorners { get; private set; }

    private void OnValidate()
    {
        if (_corners == null)
        {
            Debug.LogError("No Camera corners");
        }
    }
    private void Awake()
    {
        _cornersPosition = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0) };
        WorldPositionCorners = new Dictionary<CornerName, Vector3>();
        for (int i = 0; i < _cornersPosition.Length; i++)
        {
            Vector2 screenPosition = new Vector2(_cornersPosition[i].x * _cam.pixelWidth, _cornersPosition[i].y * _cam.pixelHeight);
            Vector3 cornerPosition = GetCameraWorldPosition(screenPosition);

            WorldPositionCorners.Add(_corners[i], cornerPosition);
        }
        
    }
    private Vector3 GetCameraWorldPosition(Vector2 cornerPosition)
    {
        return _cam.ScreenToWorldPoint(cornerPosition);
    }
    
}
