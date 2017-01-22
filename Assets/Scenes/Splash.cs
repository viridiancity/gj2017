using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	public string level = "MainMenu";
	public float setTime = 3f;
	public float sfxTime = 300f;
	public float endTime = 355f;
	public float dimTime = 3f;
	public Light dimLight;
	public float zoomSpeed = 0.2f;
	private bool fading = false;
	Camera c;

	public AudioSource sfx;

	float timer;

	// Use this for initialization
	void Start () {
		c = GetComponent<Camera> (); // searches for attached camera component
		timer = 0.0f; //initialise timer to 0

	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		c.fieldOfView -= zoomSpeed;
		if (timer > dimTime && timer < setTime) {
			dimLight.intensity -= zoomSpeed;
		} else if (timer > sfxTime && !fading) {
			sfx.Play();
		} else if (timer > setTime && !fading) {
			c.GetComponent<FadeScript>().BeginFade(1);
			fading = true;
		} else if( timer > endTime){
			//Application.LoadLevel (level);
			Debug.Log ("End");
		}

	}

    public void loadMain()
    {
        Application.LoadLevel("main");
    }
}
