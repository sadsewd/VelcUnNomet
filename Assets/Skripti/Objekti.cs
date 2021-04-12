using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objekti : MonoBehaviour
{
    public GameObject atkritumuMasina;
    public GameObject autobus;
    public GameObject atroMasina;
    [HideInInspector]
    public Vector2 atkrKoord;
    [HideInInspector]
    public Vector2 bussKoord;
    [HideInInspector]
    public Vector2 atroKoord;
    public Canvas kanva;
    public AudioSource skanasAvots;
    public AudioClip[] skanaKoAtskanot;
    public GameObject pedejaisVilktais = null;
    [HideInInspector]
    public bool vaiIstajaVieta = false;


    public void Awake()
    {
        atroKoord = atkritumuMasina.GetComponent<RectTransform>().localPosition;
        atkrKoord = atroMasina.GetComponent<RectTransform>().localPosition;
        bussKoord = autobus.GetComponent<RectTransform>().localPosition;
    }
 
}
