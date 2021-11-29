
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HazardSelectionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    //[SerializeField] private Color normalColor = Color.white;
    //[SerializeField] private Color enterColor = Color.white;
    //[SerializeField] private Color downColor = Color.white;
    [SerializeField] private string hazardMessage = "You identified a hazard!";
    [SerializeField] private string hazardID = "hazard_id";
    [SerializeField] private GameObject Object;
    [SerializeField] private GameObject ObjectFinalPOS;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();

    

    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        print("Up");

        GameManager.Instance.NewDialog(hazardMessage);
        GameManager.Instance.HazardSelected(hazardID);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
        print("Click");
    }
    public void Appear() {
        Object.SetActive(true);
    }
    public void Disappear()
    {
        Object.SetActive(false);
    }
    public void Transform()
    {
        Object.transform.position = ObjectFinalPOS.transform.position;
    }
}
