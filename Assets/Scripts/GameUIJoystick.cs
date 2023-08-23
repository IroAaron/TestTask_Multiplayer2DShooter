using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameUIJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Image Joystick;
    public Image JoystickBackground;

    private Vector2 _inputVector;
    //private NetworkVariable<Vector2> _inputVector_NV = new NetworkVariable<Vector2>();

    public void OnPointerDown (PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBackground.rectTransform,
            eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / JoystickBackground.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JoystickBackground.rectTransform.sizeDelta.y);
        }

        _inputVector = new Vector2(pos.x * 2, pos.y * 2);
        _inputVector = (_inputVector.magnitude > 1f) ? _inputVector.normalized : _inputVector;

        Joystick.rectTransform.anchoredPosition = new Vector2(
            _inputVector.x * (JoystickBackground.rectTransform.sizeDelta.x / 2),
            _inputVector.y * (JoystickBackground.rectTransform.sizeDelta.y / 2));

        //_inputVector_NV.Value = _inputVector;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        //_inputVector_NV.Value = _inputVector;
        Joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if (_inputVector.x != 0)
            return Mathf.Round(_inputVector.x);
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (_inputVector.y != 0)
            return Mathf.Round(_inputVector.y);
        else
            return Input.GetAxis("Vertical");
    }
}
