using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    public Objekti objektuSkripts;
    //Velkamam objektam piestiprinātā komponente
    private CanvasGroup kanvasGrupa;
    //Vilktā objekta atrašanās vietas koordinātu maiņai
    private RectTransform velkObjektTransf;

    void Awake()
    {
        //Piekļūst objektam piesaistītajai CanvasGroup komponentei
        kanvasGrupa = GetComponent<CanvasGroup>();
        //Piekļūst objekta RectTransform komponentei
        velkObjektTransf = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData notikums)
    {
        Debug.Log("Uzklikšķināts uz velkamā objekta!");
    }

    public void OnBeginDrag(PointerEventData notikums)
    {
        Debug.Log("Uzsākta vilkšana");
        //Attīra pēdejo vilkto objektu
        objektuSkripts.pedejaisVilktais = null;
        kanvasGrupa.alpha = 0.6f;
        //Lai objektam varētu iet cauri RayCast stars
        kanvasGrupa.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData notikums)
    {
        Debug.Log("Notiek vilkšana!");
        velkObjektTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
    }

    public void OnEndDrag(PointerEventData notikums)
    {
        //Atlaižot objektu iestata to kā pēdējo vilkto
        objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
        Debug.Log("Pēdējais vilktais objekts: " + objektuSkripts.pedejaisVilktais);
        Debug.Log("Beigta vilkšana!");
        //Atlaižot objektu tas atkal paliek necaurspīdīgs
        kanvasGrupa.alpha = 1f;

        //Pārbauda vai objekts ir vienkārši nomests vai arī nomests pareizajā vietā
        if (objektuSkripts.vaiIstajaVieta == false)
        {
            //Ja nav nomests pareizajā vietā, tad atkal padara velkamu
            kanvasGrupa.blocksRaycasts = true;
        }
        else
        {
            //Ja objekts nolikts pareizajā vietā, izmērā, rotācijā, tad pēdējo vilkto attīra
            objektuSkripts.pedejaisVilktais = null;
        }
        //Ja viens objekts nomests pareizajā vietā, tad lai varētu turpināt pārvietot pārējos objektus
        objektuSkripts.vaiIstajaVieta = false;
    }

}
