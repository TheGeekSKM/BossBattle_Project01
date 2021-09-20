
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    [SerializeField] GameObject _uiElement;

    [SerializeField] GameObject _followObject;
    [SerializeField] Vector3 _desiredLocation;

    private void Update()
    {
        if (_uiElement != null)
        {
            Vector3 uiPos = Camera.main.WorldToScreenPoint(transform.position);
            _uiElement.transform.position = uiPos;
        }

        transform.position = _followObject.transform.position + _desiredLocation;
    }
}
