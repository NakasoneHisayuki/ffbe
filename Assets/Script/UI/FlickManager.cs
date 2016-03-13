using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
public class FlickManager : MonoBehaviour {

	public Camera mainCamera;
	public Transform flickContents;
	RectTransform rectTrans1;
	RectTransform rectTrans2;
	public Button[] buttons;

	public float slideSpeed;
	private float zeroPosi = 0.0f;
	private float middleDistance = 200.0f;
	private float flickPosition = 0.0f;
	public float[] flickPositionX;
	public float[] imageScaseSize;
	private float[] flickPosiX;
	float scaleSizeSpeed = 0.0f;
	float distance = 0.0f;
	private int[] chengeScaleObj = new int[2];

	public bool[] isFlickPosi;
	private bool isButton = false;
	private bool isGetMouseButton = false;
	private bool isMoveObj = false;

	private Vector2 flickData;
	private Vector2 flickMoveData;
	private Vector2 moveObjPosition = new Vector2(0.0f,0.0f);

	public slider sliders;
	public enum slider{
		left,
		right
	}

	public outside outsideObj;
	public enum outside{
		World,
		Coroshiam,
		Summons,
		Ijigen
	}
	


	// Use this for initialization
	void Start () {
		this.outsideObj = outside.Summons;

		for(int i = 0; i < this.isFlickPosi.Length; i ++){
			this.isFlickPosi[i] = false;
		}

	}

	// Update is called once per frame
	void Update () {
	
		if(this.isButton){
			this.moveObjPosition = this.TouchPosition();
		}
		if(this.isMoveObj){
			Debug.Log(this.moveObjPosition);
			this.MoveObj(this.moveObjPosition);	
		}
	}

	float posi = 0.0f;
	private void MoveObj(Vector2 movePosi){
		this.Move(movePosi);

	}

	private void Move(Vector2 movePosi){

		if(this.isButton){
			this.flickContents.localPosition = new Vector2(movePosi.x, movePosi.y);
		}else{
			this.posi = this.Distance(movePosi);
			Debug.Log("posi : " + posi);

			if(Math.Floor(posi) == 0.0f || Math.Floor(posi) == 315.0f){
				Debug.Log("end");
				this.isMoveObj = false;
			}else{
				
				if(posi >= this.middleDistance){
					// 戻る
					Debug.Log("戻る");
					this.flickContents.localPosition = Vector2.MoveTowards(new Vector2(this.zeroPosi,this.zeroPosi), new Vector2(movePosi.x,this.zeroPosi), 2.0f);
				}else{
					// 移動
					Debug.Log("移動");
					this.flickContents.localPosition = Vector2.MoveTowards(new Vector2(this.flickPosition,this.zeroPosi), new Vector2(movePosi.x,this.zeroPosi), 2.0f);
					
				}
				
			}
			
		}
		
	}

	/*
	 * Start地点からEnd地点の距離を測る
	 */
	private float Distance(Vector2 startDistance){

		switch(this.sliders){
			case slider.right:
				this.distance = Vector2.Distance(new Vector2(startDistance.x, this.zeroPosi), new Vector2(this.flickPositionX[1], this.zeroPosi));
				this.flickPosition = this.flickPositionX[1];
//				if(Math.Floor(flickContents.localPosition.x) >= 10.0f && this.isFlickPosi[0]){
//					this.OutsideObject();
//					this.isFlickPosi[0] = false;
//					rectTrans1 = this.buttons[this.chengeScaleObj[1]].GetComponent<RectTransform>();
//					rectTrans2 = this.buttons[this.chengeScaleObj[0]].GetComponent<RectTransform>();
//
//				}
				
			break;
			case slider.left:
				this.distance = Vector2.Distance(new Vector2(startDistance.x, this.zeroPosi), new Vector2(this.flickPositionX[0], this.zeroPosi));
				this.flickPosition = this.flickPositionX[0];
//				if(Math.Floor(flickContents.localPosition.x) <= -10.0f && this.isFlickPosi[1]){
//					this.OutsideObject();
//					this.isFlickPosi[1] = false;
//					rectTrans1 = this.buttons[this.chengeScaleObj[0]].GetComponent<RectTransform>();
//					rectTrans2 = this.buttons[this.chengeScaleObj[1]].GetComponent<RectTransform>();
//				}

			break;
		}
//		this.ScaleSizeObj(rectTrans1,rectTrans2);
		return distance;

	}

	/*
	 *  外に出てるオブジェクト確認
	 */
	private void OutsideObject(){

		for(int i = 0; i < this.buttons.Length; i ++){

			if(this.sliders == slider.right){
				if(Math.Floor(this.buttons[i].gameObject.transform.localPosition.x) == 618.0f){
					this.buttons[i].gameObject.transform.localPosition = new Vector2(-618.0f,-325.0f);
					this.CheckRightObject(i);
					break;
				}else if(Math.Floor(this.buttons[i].gameObject.transform.localPosition.x) == -618.0f){
					this.CheckRightObject(i);
					break;
				}
			}

			if(this.sliders == slider.left){
				if(Math.Floor(this.buttons[i].gameObject.transform.localPosition.x) == -618.0f){
					this.buttons[i].gameObject.transform.localPosition = new Vector2(618.0f,-325.0f);
					this.CheckLeftObject(i);
					break;
				}else if(Math.Floor(this.buttons[i].gameObject.transform.localPosition.x) == 618.0f){
					this.CheckLeftObject(i);
					break;
				}
			}
		}
	}

	private void CheckLeftObject(int objNum){

		this.chengeScaleObj = new int[2];

		if(objNum == 0){
			this.chengeScaleObj[0] = 2;
			this.chengeScaleObj[1] = 1;
		}else if(objNum == 3){
			this.chengeScaleObj[0] = 1;
			this.chengeScaleObj[1] = 0;

		}else{
			this.chengeScaleObj[0] = objNum - 2;
			this.chengeScaleObj[1] = objNum + 1;
		} 
	}
	private void CheckRightObject(int objNum){

		this.chengeScaleObj = new int[2];
		
		if(objNum == 0){
			this.chengeScaleObj[0] = 2;
			this.chengeScaleObj[1] = 1;
		}else if(objNum == 3){
			this.chengeScaleObj[0] = 1;
			this.chengeScaleObj[1] = 0;
			
		}else{
			this.chengeScaleObj[0] = objNum - 2;
			this.chengeScaleObj[1] = objNum - 1;
		} 
	}

	private void ScaleSizeObj(RectTransform obj1, RectTransform obj2){


		if(obj1){
			float scaleSize = 1.0f + scaleSizeSpeed * 0.05f;
			if(scaleSize >= 0.9f)obj1.localScale = new Vector2(scaleSize,scaleSize);
		}
		if(obj2){
			float scaleSize = 0.9f - scaleSizeSpeed * 0.05f;
			if(scaleSize <= 1.0f)obj2.localScale = new Vector2(scaleSize,scaleSize);
		}
	}
	private Vector2 positionData = new Vector2(0.0f,0.0f);

	/*
	 * 
	 */
	private Vector2 TouchPosition(){
		if(Input.GetMouseButtonDown(0)){
			this.flickData = this.mainCamera.ScreenToWorldPoint(Input.mousePosition);
			this.isGetMouseButton = true;
			this.isMoveObj = true;
		}

		if(Input.GetMouseButtonUp(0)){
			this.isGetMouseButton = false;
			this.isButton = false;
		}
		if(this.isGetMouseButton){
			this.flickMoveData = this.mainCamera.ScreenToWorldPoint(Input.mousePosition);
			positionData = new Vector2((this.flickData.x + this.flickMoveData.x) * this.slideSpeed, this.zeroPosi);
			this.scaleSizeSpeed = positionData.x * 0.01f;
			double posi = Math.Floor(positionData.x);

			if(posi >= 0){
				this.sliders = slider.right;
				this.isFlickPosi[0] = true;
			}else if(posi <= 0){
				this.sliders = slider.left;
				this.isFlickPosi[1] = true;
			}
			return positionData;
		}

		return positionData;
	}


	/*
	 * ClickBtn
	 */
	public void OnClickWorldButtonDown(){
		this.isButton = true;
	}
	
	public void OnClickWorldButtonUp(){

	}
}
