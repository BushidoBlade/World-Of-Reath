using UnityEngine;
using System.Collections;

public class GUITextRotater : MonoBehaviour {
	public Font font;
	private GUIStyle currentStyle = null;
	
	private void InitStyles() {
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.font = font;
			currentStyle.normal.textColor = Color.red;
			currentStyle.fontSize = 30;
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

	void OnGUI(){
		InitStyles ();
		GUIUtility.RotateAroundPivot(-10, new Vector2(160, 30));
		GUI.Box(new Rect(510, 200, 200, 40), "Not Available", currentStyle);
		GUI.Box(new Rect(500, 270, 200, 40), "Not Available", currentStyle);
	}
}
