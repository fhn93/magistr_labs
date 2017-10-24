using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moving : MonoBehaviour {
	private const int MnS = 3;//множитель скорости
	private const int MaxFlavers = 10;//максимальное колиетво цветков на экране
	private Rigidbody body;//"персонаж"
	private int score=0;

	public Text TS;
	public Transform cub;


	// Use this for initialization
	void create()
	{
		Instantiate(cub,new Vector3(Random.Range(-4.5f,4.5f),0.0f,Random.Range(-4.5f,4.5f)),Quaternion.identity);
	}

	void Start () {
		body=GetComponent<Rigidbody>();//наследуем свойства "персонжа"
	}
	
	// Update is called once per frame
	void Update () {
		FixUpdate();
		if (Input.GetKey("escape"))//выход из игры
			Application.Quit();		
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("candy"))
			{
				Destroy(col.gameObject);
			score++;
			create ();
			TS.text = "SCORE:   " + score;
			}
	}


	void FixUpdate(){
		
		float hor = Input.GetAxis ("Horizontal");//берем компоненты вектора силы
		float ver = Input.GetAxis("Vertical");
		Vector3 VC = new Vector3(hor,0,ver);//формируем вектор силы

		body.AddForce(VC*MnS);//действие силы на "персонажа"
	}
}