using UnityEngine;
using System.Collections;

public class PlantEnemyHealth : MonoBehaviour {
	public int maxHealth = 40;
	public int currentHealth = 40;
	private GUIStyle currentStyle = null;

	private void InitStyles() {
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( 2, 2, new Color( 1f, 0f, 0f, 1f ) );
		}
	}
	
	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void adjustHealth(int hp){
		currentHealth += hp;
		if (currentHealth < 0)
			currentHealth = 0;
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
		if (maxHealth < 1)
			maxHealth = 1;  // no divide by 0
	}
	void OnGUI(){
		InitStyles();
		//GUI.Box (new Rect (transform.position.x,transform.position.y,300,35), "", currentStyle);
	}
}
