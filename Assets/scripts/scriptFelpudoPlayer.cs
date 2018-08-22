using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptFelpudoPlayer : MonoBehaviour {

	bool iniciouJogo;
	bool acabouJogo;
	Vector2 forcaImpulso = new	Vector2(0, 400);
	public GameObject particulaPena;
	GameObject gameEngine;
	// Use this for initialization
	void Start () {
		gameEngine = GameObject.FindGameObjectWithTag("GameEngine");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && !acabouJogo)
		{
			if(!iniciouJogo)
			{
				iniciouJogo =true;
				GetComponent<Rigidbody2D>().isKinematic =false;
				gameEngine.SendMessage("ComecouJogo");
			}
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce(forcaImpulso);
			GameObject particula = Instantiate(particulaPena);
			particula.transform.position = gameObject.transform.position;
		}
		transform.rotation = Quaternion.Euler(0,0, GetComponent<Rigidbody2D>().velocity.y * 5f);

		Vector2 stagePos = Camera.main.WorldToScreenPoint(transform.position);
		if(stagePos.y > Screen.height || stagePos.y < 0)
		{
			acabouJogo = true;
			gameEngine.SendMessage("FimDeJogo");
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D()
	{
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		GetComponent<Rigidbody2D>().AddForce(new Vector2(-500,0));
		acabouJogo = true;
		gameEngine.SendMessage("FimDeJogo");
	}
}
