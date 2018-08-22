using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPrincipal : MonoBehaviour {
	public GameObject objetoCanos;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ComecouJogo(){
		InvokeRepeating("CriaCanos", 0f, 1.5f);
	}

	void CriaCanos()
	{
		float randomPos = (3.0f * Random.value) - 1.5f;
		GameObject cano = Instantiate(objetoCanos);
		cano.transform.localScale = new Vector3(1.65f, 1.65f, 1.65f);
		cano.transform.position = new Vector3(10, randomPos, 0);
	}

	public void FimDeJogo(){
		CancelInvoke("CriaCanos");
		foreach(GameObject objeto in GameObject.FindGameObjectsWithTag("ImagemFundo"))
		{
			objeto.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		foreach(GameObject objeto in GameObject.FindGameObjectsWithTag("AreaVao"))
		{
			objeto.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}
}
