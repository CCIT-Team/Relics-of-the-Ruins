using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mmmm : MonoBehaviour, IPointerClickHandler
{
    Vector2 sizeCalibrator,localPos;
    RectTransform rt;
    [SerializeField]
    Camera mapCam;

    Ray ray;
    RaycastHit hit;

    public void OnPointerClick(PointerEventData eventData)
    {
        bool bIsPointInRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.pressPosition, null, out localPos);

        if (!bIsPointInRect)
        {
            return;
        }

        localPos += sizeCalibrator;

        localPos.x /= rt.rect.width;
        localPos.y /= rt.rect.height;

        ray = mapCam.ViewportPointToRay(localPos);
        
        Physics.Raycast(ray, out hit, 500f);

        Debug.DrawRay(ray.origin, ray.direction * 500f, Color.red, 100f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RawImage>().rectTransform;
        sizeCalibrator.x = rt.rect.width / 2;
        sizeCalibrator.y = rt.rect.height / 2;
        
    }

}
