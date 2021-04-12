using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
   
    public Objekti objektuSkripts;
    private CanvasGroup kanvasGroup;
    private RectTransform velkObjectTransf;

    void Awake()
    {
        kanvasGroup = GetComponent<CanvasGroup>();
        velkObjectTransf = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData notikums) 
    {
        Debug.Log("klikskis");
    }

    public void OnBeginDrag(PointerEventData notikums)
    {
        Debug.Log("Iesākts vilkt objektu");
        objektuSkripts.pedejaisVilktais = null;
        kanvasGroup.alpha = 0.6f;
        kanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData notikums)
    {
        Debug.Log("Notiek vilkšana!");
       velkObjectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
    }

    public void OnEndDrag(PointerEventData notikums)
    {
        Debug.Log("Pēdejais vilktais objekts: "+objektuSkripts.pedejaisVilktais);
        Debug.Log("Beigta vilkšana");
        objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
        kanvasGroup.alpha = 1f;

        if(objektuSkripts.vaiIstajaVieta == false)
        {
            kanvasGroup.blocksRaycasts = true;
        }
        else
        {
            objektuSkripts.pedejaisVilktais = null;
        }
        objektuSkripts.vaiIstajaVieta = false;
    }

}
