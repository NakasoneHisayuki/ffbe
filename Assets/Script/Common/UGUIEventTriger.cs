using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UGUIEventTriger: MonoBehaviour,
IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler, IPointerExitHandler
{
	
	
	[SerializeField]
	UnityEngine.Events.UnityEvent onClick = new UnityEngine.Events.UnityEvent();
	[SerializeField]
	UnityEngine.Events.UnityEvent onDown = new UnityEngine.Events.UnityEvent();
	[SerializeField]
	UnityEngine.Events.UnityEvent onEnter = new UnityEngine.Events.UnityEvent();
	[SerializeField]
	UnityEngine.Events.UnityEvent onUp = new UnityEngine.Events.UnityEvent();
	[SerializeField]
	UnityEngine.Events.UnityEvent onExit = new UnityEngine.Events.UnityEvent();
	
	
	//  クリック判定
	public void OnPointerClick(PointerEventData eventData)
	{
		onClick.Invoke();
	}
	
	//  ボタンを押した瞬間
	public void OnPointerDown(PointerEventData eventData)
	{
		onDown.Invoke();
	}
	
	//  マウスポインタが当たり判定に入ったとき
	public void OnPointerEnter(PointerEventData eventData)
	{
		onEnter.Invoke();
	}
	
	//  ボタンを押してはなした瞬間
	public void OnPointerUp(PointerEventData eventData)
	{
		onUp.Invoke();
	}
	
	//  マウスポインタが当たり判定から出たとき
	public void OnPointerExit(PointerEventData eventData)
	{
		onExit.Invoke();
	}
}