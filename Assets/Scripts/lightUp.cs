using UnityEngine;
using System.Collections;

public class lightUp : MonoBehaviour
{
    public Material lightUpMaterial;
	public GameObject gameLogic;
	public Material defaultMaterial;

	// Use this for initialization
	void Start () {
        this.GetComponent<MeshRenderer>().material = defaultMaterial;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
	public void patternLightUp(float duration) { //The lightup behavior when displaying the pattern
		StartCoroutine(lightFor(duration));
	}


	public void gazeLightUp() {
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		//this.GetComponentInChildren<ParticleSystem>().enableEmission = true; //Turn on particle emmission
		this.GetComponent<GvrAudioSource>().Play();
        GameLogic a = gameLogic.GetComponent<GameLogic>();
        a.playerSelection(this.gameObject);
        //this.GetComponent<MeshRenderer>().material = defaultMaterial;
        //gameLogic.GetComponent<gameLogic>().playerSelection(this.gameObject);


    }
    public void playerSelection()
    {
        GameLogic a = gameLogic.GetComponent<GameLogic>();
        a.playerSelection(this.gameObject);
        //GameLogic.GetComponent<gameLogic>().playerSelection(this.gameObject);
        //this.GetComponent<GvrAudioSource>().Play();
    }
    public void aestheticReset() {
		this.GetComponent<MeshRenderer>().material = defaultMaterial; //Revert to the default material
		//this.GetComponentInChildren<ParticleSystem>().enableEmission = false; //Turn off particle emission
	}

	public void patternLightUp() { //Lightup behavior when the pattern shows.
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		//this.GetComponentInChildren<ParticleSystem>().enableEmission = true; //Turn on particle emmission
		//this.GetComponent<GvrAudioSource> ().Play (); //Play the audio attached
	}


	IEnumerator lightFor(float duration) { //Light us up for a duration.  Used during the pattern display
		patternLightUp ();
        yield return new WaitForSeconds(0.5f);// duration-.1f);
		aestheticReset ();
	}
}
