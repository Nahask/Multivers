using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class manaBar : MonoBehaviour {

	public RectTransform manaTransform;
	public Player player;
	private float hiddenY;
	private float minXValue;
	private float maxXValue;

	public Image visualMana;

	void Start () {
		hiddenY = manaTransform.position.y;
		maxXValue = manaTransform.position.x;
		minXValue = manaTransform.position.x - manaTransform.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		HandleMana ();
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
	}

	private void HandleMana()
	{
		float currentXValue = MapValues (player.currentMana, player.minMana, player.maxMana, minXValue, maxXValue);
		manaTransform.position = new Vector3 (currentXValue, hiddenY);
	}
}
