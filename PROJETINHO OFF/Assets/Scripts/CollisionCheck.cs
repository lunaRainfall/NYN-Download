using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
	public PlatformController controlScript;
	private bool triggerRed;
	private bool triggerGreen;
	private bool triggerBlue;
	private bool triggerCyan;
	private bool triggerMagenta;
	private bool triggerYellow;
	private bool triggerWhite;

	public Transform colCheck;
	public float checkRadius;
    public Vector2 bottomOffset;

	public LayerMask greenObjectsLayer;
	public LayerMask blueObjectsLayer;
	public LayerMask redObjectsLayer;
	public LayerMask CyanObjectsLayer;
	public LayerMask MagentaObjectsLayer;
	public LayerMask YellowObjectsLayer;
	public LayerMask WhiteObjectsLayer;


    void Update()
 {
		triggerGreen = Physics2D.OverlapCircle(colCheck.position, checkRadius, greenObjectsLayer);
		triggerBlue = Physics2D.OverlapCircle(colCheck.position, checkRadius, blueObjectsLayer);
		triggerRed = Physics2D.OverlapCircle(colCheck.position, checkRadius, redObjectsLayer);
		triggerCyan = Physics2D.OverlapCircle(colCheck.position, checkRadius, CyanObjectsLayer);
		triggerMagenta = Physics2D.OverlapCircle(colCheck.position, checkRadius, MagentaObjectsLayer);
		triggerYellow = Physics2D.OverlapCircle(colCheck.position, checkRadius, YellowObjectsLayer);
		triggerWhite = Physics2D.OverlapCircle(colCheck.position, checkRadius, WhiteObjectsLayer);


		if (triggerGreen == true)
		{
			controlScript.isCollidingGreen = true; 
		}
	
		else
		{
			controlScript.isCollidingGreen = false;     
		}

		if (triggerBlue == true)
		{
			controlScript.isCollidingBlue = true; 
		}

		else
		{
			controlScript.isCollidingBlue = false;     
		}

		if (triggerRed == true)
		{
			controlScript.isCollidingRed = true; 
		}

		else
		{
			controlScript.isCollidingRed = false;     
		}


		if (triggerCyan == true) {
			controlScript.isCollidingCyan = true;
		}

		else{
			controlScript.isCollidingCyan = false;
		}

		if (triggerMagenta == true) {
			controlScript.isCollidingMagenta = true;
		}

		else{
			controlScript.isCollidingMagenta = false;
		}

		if (triggerYellow == true) {
			controlScript.isCollidingYellow = true;
		}

		else{
			controlScript.isCollidingYellow = false;
		}

		if (triggerWhite == true) {
			controlScript.isCollidingWhite = true;
		}

		else{
			controlScript.isCollidingWhite = false;
		}

	}

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;

        //var positions = new Vector2[] { bottomOffset };

        //Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRadius);
    }
}

