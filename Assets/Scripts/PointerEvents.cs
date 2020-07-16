﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IInteractable
{
    [SerializeField] private Color normalColor;
    [SerializeField] private Color enterColor;
    [SerializeField] private Color downColor;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();

    [SerializeField]
    private Image image;

    bool isHovering = false;

    private void Awake()
    {
        image.color = Color.green;
    }

    private void Update()
    {
        isHovering = false;
        image.color = Color.green;
    }

    private void LateUpdate()
    {
        if(isHovering)
            GetComponent<Image>().color = Color.red;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = enterColor;
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
        Debug.Log("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image.color = downColor;
        Debug.Log("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.color = enterColor;
        Debug.Log("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
        Debug.Log("Click");
    }

    public void OnPointerClick()
    {
        OnClick.Invoke();
        Debug.Log("Click");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("pointer enter: " + collision.collider.gameObject.name);
        image.color = enterColor;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("pointer exit: " + collision.collider.gameObject.name);
        image.color = normalColor;
    }

    public void OnHover()
    {
        Debug.Log("pointing at: " + gameObject.name);
        isHovering = true;
    }

    void IInteractable.OnClick()
    {
        gameObject.GetComponent<PointerEvents>().OnPointerClick();
    }
}
