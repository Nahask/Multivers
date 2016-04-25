using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderVolumeScript : MonoBehaviour {

	public Slider slider;
	private GameObject audioObject;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioObject = GameObject.Find("Music");
		audioSource = audioObject.GetComponent<AudioSource>();
		slider.value = audioSource.volume;
	}
	
	// Update is called once per frame
	void Update () {
		slider.onValueChanged.AddListener((value) => { audioSource.volume = value; });
	}
}
