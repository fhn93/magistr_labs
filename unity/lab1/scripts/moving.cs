using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {
	private const int MnS = 3;//множитель скорости
	private const int MaxFlavers = 10;//максимальное колиетво цветков на экране
	private Rigidbody body;//"персонаж"
	private object[] ArrayFlovers;
	// Use this for initialization
	void Start () {
		body=GetComponent<Rigidbody>();//наследуем свойства "персонжа"
	}
	
	// Update is called once per frame
	void Update () {
		FixUpdate();
		if (Input.GetKey("escape"))//выход из игры
			Application.Quit();		
	}

	void FixUpdate(){
		
		float hor = Input.GetAxis ("Horizontal");//берем компоненты вектора силы
		float ver = Input.GetAxis("Vertical");
		Vector3 VC = new Vector3(hor,0,ver);//формируем вектор силы
	
		body.AddForce(VC*MnS);//действие силы на "персонажа"
	}
}