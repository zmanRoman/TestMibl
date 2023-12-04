using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    private const float MaxAllowedSize = 70f;
    public float Speed { get; private set; } = 0.0f;
    public Vector2 Direction { get; private set; } = Vector2.zero;
    private RectTransform _rect;
    private Vector2 _startPosition = Vector2.zero;
    private Vector2 _position = Vector2.zero;
    
    private void Start()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void OnPointerDown(BaseEventData data)
    {
        var pntr = (PointerEventData)data;
        _startPosition = pntr.position;
    }

    public void OnDrag(BaseEventData data)
    {
        var pntr = (PointerEventData)data;
        _position = pntr.position - _startPosition;
        float size = _position.magnitude;
        if (size > MaxAllowedSize)
        {
            Speed = 1.0f;
            _position = _position / size * MaxAllowedSize;
        }
        else
        {
            Speed = size / MaxAllowedSize;
        }
        Direction = _position / size;
        _rect.localPosition = _position;
    }
    
    public void OnPointerUp(BaseEventData data)
    {
        Speed = 0f;
        Direction = Vector2.zero;
        _rect.localPosition = Vector2.zero;
    }
    
}
