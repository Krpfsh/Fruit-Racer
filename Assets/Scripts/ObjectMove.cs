using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectMove : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected RectTransform capturedObj;

    [SerializeField] protected Canvas canvas;

    [SerializeField] protected bool fixX, fixY;
    [SerializeField] protected bool _canMove = true;

    [Space]
    [SerializeField] private RectTransform _leftPointConstraint;
    [SerializeField] private RectTransform _rightPointConstraint;
    [SerializeField] private RectTransform _topPointConstraint;
    [SerializeField] private RectTransform _bottomPointConstraint;

    [Space]
    [SerializeField] protected bool returnToBase;

    [SerializeField] protected float speed = 400;

    [SerializeField] private UnityEvent OnHolded;
    [SerializeField] private UnityEvent OnReleased;
    
    protected bool isReturn;

    protected Vector3 basePos;

    public void ChangeReturnToBase(bool val)
    {
        returnToBase = val;
        basePos = transform.localPosition;
    }

    public void SetMove() => _canMove = true;
    public void BlockMove()
    {
        _canMove = false;
        Release();
    }

    public void ChangeSpeed(float val) => speed = val;

    private void Awake()
    {
        if (capturedObj == null) capturedObj = GetComponent<RectTransform>();

        if (returnToBase) basePos = transform.localPosition;

        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    private void Del(bool val)
    {
        Destroy(this);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (!_canMove) return;
        
        Vector2 delta = eventData.delta;

        if (fixY)
        {
            delta.y = 0;
        }
        if (fixX)
        {
            delta.x = 0;
        }

        capturedObj.localPosition += (Vector3)delta / canvas.scaleFactor;

        UpdatePositionByConstraint();
    }

    private void UpdatePositionByConstraint()
    {
        if (_leftPointConstraint && capturedObj.position.x < _leftPointConstraint.position.x)
        {
            capturedObj.position = new Vector3(_leftPointConstraint.position.x, capturedObj.position.y,
                capturedObj.position.z);
        }

        if (_rightPointConstraint && capturedObj.position.x > _rightPointConstraint.position.x)
        {
            capturedObj.position = new Vector3(_rightPointConstraint.position.x, capturedObj.position.y,
                capturedObj.position.z);
        }

        if (_bottomPointConstraint && capturedObj.position.y < _bottomPointConstraint.position.y)
        {
            capturedObj.position = new Vector3(capturedObj.position.x, _bottomPointConstraint.position.y,
                capturedObj.position.z);
        }
        
        if (_topPointConstraint && capturedObj.position.y > _topPointConstraint.position.y)
        {
            capturedObj.position = new Vector3(capturedObj.position.x, _topPointConstraint.position.y,
                capturedObj.position.z);
        }
    }


    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (!_canMove) return;
        
        isReturn = false;
        OnHolded?.Invoke();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (!_canMove) return;

        Release();
    }

    private void Release()
    {
        if (returnToBase) isReturn = true;

        OnReleased?.Invoke();
    }

    protected virtual void Update()
    {
        if (!isReturn) return;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, basePos,
            speed * Time.deltaTime);

        if (Vector3.Distance(basePos, transform.localPosition) < 5) isReturn = false;
    }
}
