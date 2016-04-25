using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthBar : MonoBehaviour {

	public RectTransform healthTransform;
	public Player player;
	private float hiddenY;
	private float minXValue;
	private float maxXValue;

	public Image visualHealth;

	void Start () {
		hiddenY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXValue = healthTransform.position.x - healthTransform.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		HandleHealth ();
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
	}

	private void HandleHealth()
	{
		float currentXValue = MapValues (player.currentHealth, player.minHealth, player.maxHealth, minXValue, maxXValue);

		healthTransform.position = new Vector3 (currentXValue, hiddenY);

		if (player.currentHealth > player.maxHealth / 2) {
			visualHealth.color = new Color32 ((byte)MapValues(player.currentHealth, player.maxHealth/2, player.maxHealth , 255, 0),255, 0, 255); 
		} else {
			visualHealth.color = new Color32 (255, (byte)MapValues (player.currentHealth, 0, player.maxHealth / 2, 0, 255), 0, 255);
		}
	}
}
