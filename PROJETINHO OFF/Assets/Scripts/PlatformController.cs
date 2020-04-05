using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlatformController : MonoBehaviour
{
    [Header ("Color States")]
    public bool greenState = false;
    public bool blueState = false;
    public bool redState = false;
    public bool cyanState = false;
    public bool magentaState = false;
    public bool yellowState = false;
    public bool whiteState = false;

    [Header("Game Objects")]
    public GameObject blue;
    public GameObject red;
    public GameObject green;
	public GameObject cyan;
	public GameObject magenta;
	public GameObject yellow;
	public GameObject white;

    [Header("GameObj Layers")]
    public GameObject character;
    private GameObject[] moveLayerGreen;
    private GameObject[] moveLayerBlue;
    private GameObject[] moveLayerRed;
	private GameObject[] moveLayerCyan;
	private GameObject[] moveLayerMagenta;
	private GameObject[] moveLayerYellow;
	private GameObject[] moveLayerWhite;

    [Header ("Is Colliding")]
    public bool isCollidingGreen = false;
    public bool isCollidingBlue = false;
    public bool isCollidingRed = false;
	public bool isCollidingCyan = false;
	public bool isCollidingMagenta = false;
	public bool isCollidingYellow = false;
	public bool isCollidingWhite = false;

	[Header("Hub")]
	public HubController hubControl;

	[Header("Particle Effects")]
	public ParticlesColor particles;

	[SerializeField] private ParticleSystem[] backgroundRed;
	[SerializeField] private ParticleSystem[] backgroundGreen;
	[SerializeField] private ParticleSystem[] backgroundBlue;

	[SerializeField] private ParticleSystem[] backgroundCyan;
	[SerializeField] private ParticleSystem[] backgroundMagenta;
	[SerializeField] private ParticleSystem[] backgroundYellow;

	[SerializeField] private ParticleSystem[] backgroundWhite;

	[Space]

	[SerializeField] private Gradient redColor;
	[SerializeField] private Gradient greenColor;
	[SerializeField] private Gradient blueColor;

	[SerializeField] private Gradient cyanColor;
	[SerializeField] private Gradient magentaColor;
	[SerializeField] private Gradient yellowColor;

	[SerializeField] private Gradient rainbowColor;

	

	// Use this for initialization

	void Start()
    {

        //10 = Invisible Platform Green
        //11 - Invisible Platform Blue
        //12 - Invisible Platform Red

        moveLayerGreen = GameObject.FindGameObjectsWithTag("Green");
        moveLayerBlue = GameObject.FindGameObjectsWithTag("Blue");
        moveLayerRed = GameObject.FindGameObjectsWithTag("Red");
        moveLayerCyan = GameObject.FindGameObjectsWithTag("Cyan");
        moveLayerMagenta = GameObject.FindGameObjectsWithTag("Magenta");
        moveLayerYellow = GameObject.FindGameObjectsWithTag("Yellow");
        moveLayerWhite = GameObject.FindGameObjectsWithTag("White");
		/*
        moveLayerRed.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
        moveLayerGreen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
        moveLayerBlue.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
        moveLayerCyan.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        moveLayerMagenta.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        moveLayerYellow.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        moveLayerWhite.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
		*/

		ColorStart();
    }

    void Update()
    {

		moveLayerGreen = GameObject.FindGameObjectsWithTag("Green");
		moveLayerBlue = GameObject.FindGameObjectsWithTag("Blue");
		moveLayerRed = GameObject.FindGameObjectsWithTag("Red");
		moveLayerCyan = GameObject.FindGameObjectsWithTag("Cyan");
		moveLayerMagenta = GameObject.FindGameObjectsWithTag("Magenta");
		moveLayerYellow = GameObject.FindGameObjectsWithTag("Yellow");
		moveLayerWhite = GameObject.FindGameObjectsWithTag("White");

		particles.UpdateParticleColor();

		if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetButtonDown("GreenButton"))
        {
            if (greenState == true)
            {

                greenState = false;
                green.layer = 10;
                //moveLayerGreen.layer = 10;
                //moveLayerGreen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
				ColorUpdate("green", .18f, 10);
				ParticleEffectsUpdate("green", false);
				CombinationsUpdate("green", false);
				hubControl.HubUpdate("green", false);
			}
            else
            {
				if (isCollidingGreen == false)
                {
					if (!((isCollidingCyan == true && blueState == true) || (isCollidingYellow == true && redState == true) || (isCollidingWhite == true && magentaState == true)))
					{
						greenState = true;
						green.SetActive (true);
						green.layer = 8;
						//moveLayerGreen.layer = 8;
						//moveLayerGreen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
						ColorUpdate("green", 1f, 8);
						ParticleEffectsUpdate("green", true);
						CombinationsUpdate("green", true);
						hubControl.HubUpdate("green", true);
					}
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetButtonDown("BlueButton"))
        {
            if (blueState == true)
            {

                blueState = false;
                blue.layer = 11;
                //moveLayerBlue.layer = 11;
                //moveLayerBlue.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
				ColorUpdate("blue", .18f, 11);
				ParticleEffectsUpdate("blue", false);
				CombinationsUpdate("blue", false);
				hubControl.HubUpdate("blue", false);
			}

            else
            {
				if (isCollidingBlue == false)
				{
					if (!((isCollidingCyan == true && greenState == true) || (isCollidingMagenta == true && redState == true) || (isCollidingWhite == true && yellowState == true))) {
						//|| (isCollidingCyan == false && greenState == true) || (isCollidingMagenta == false && redState == true)
						blueState = true;
						blue.SetActive (true);
						blue.layer = 8;
						//moveLayerBlue.layer = 8;
						//moveLayerBlue.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
						ColorUpdate("blue", 1f, 8);
						ParticleEffectsUpdate("blue", true);
						CombinationsUpdate("blue", true);
						hubControl.HubUpdate("blue", true);
					}
                }

            }
        }
		if (Input.GetKeyDown (KeyCode.J) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetButtonDown("RedButton")) {
			if (redState == true) {

				redState = false;
				red.layer = 12;
				//moveLayerRed.layer = 12;
				//moveLayerRed.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
				ColorUpdate("red", .18f, 12);
				ParticleEffectsUpdate("red", false);
				CombinationsUpdate("red", false);
				hubControl.HubUpdate("red", false);
			} 
			else
			{
				if (isCollidingRed == false)
				{
					if (!((isCollidingYellow == true && greenState == true) || (isCollidingMagenta == true && blueState == true) || (isCollidingWhite == true && cyanState == true))) {
						//|| (isCollidingMagenta == false && blueState == true) || (isCollidingYellow == false && greenState == true)
						redState = true;
						red.SetActive (true);
						red.layer = 8;
						//moveLayerRed.layer = 8;
						//moveLayerRed.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
						ColorUpdate("red", 1f, 8);
						ParticleEffectsUpdate("red", true);
						CombinationsUpdate("red", true);
						hubControl.HubUpdate("red", true);
					}
                }
			}
		}


			//Cores CMY +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
			if (blueState == true && greenState == true)
			{
				
				//cyanState = true;
				//cyan.SetActive(true);
				//cyan.layer = 8;

				//moveLayerCyan.layer = 8;
				//moveLayerCyan.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
				//ColorUpdate("cyan", 1f, 8);
		}

			else
			{
				//cyanState = false;
				//cyan.layer = 13;

				//moveLayerCyan.layer = 13;
				//moveLayerCyan.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
				//ColorUpdate("cyan", .08f, 13);
		}




			if (redState == true && blueState == true) {
				//magentaState = true;
				//magenta.SetActive (true);
				//magenta.layer = 8;

				//moveLayerMagenta.layer = 8;
				//moveLayerMagenta.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
				//ColorUpdate("magenta", 1f, 8);
		} 

			else {
				//magentaState = false;
				//magenta.layer = 14;

				//moveLayerMagenta.layer = 14;
				//moveLayerMagenta.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
				//ColorUpdate("magenta", .08f, 14);
		}


			if (greenState == true && redState == true) {

				//yellowState = true;
				//yellow.SetActive (true);
				//yellow.layer = 8;

				//moveLayerYellow.layer = 8;
				//moveLayerYellow.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
				//ColorUpdate("yellow", 1f, 8);
		} 

			else {
				//yellowState = false;
				//yellow.layer = 15;

				//moveLayerYellow.layer = 15;
				//moveLayerYellow.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
				//ColorUpdate("yellow", .08f, 15);
		}

			if (greenState == true && blueState == true && redState == true) {
				//whiteState = true;
				//white.SetActive (true);
				//white.layer = 8;

				//moveLayerWhite.layer = 8;
				//moveLayerWhite.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
				//ColorUpdate("white", 1f, 8);
		} 

			else {
				//whiteState = false;
				//white.layer = 16;

				//moveLayerWhite.layer = 16;
				//moveLayerWhite.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
				//ColorUpdate("white", .08f, 16);
		}
    }

	public void ColorStart()
	{
        #region Iniciando Cores
        for (int i = 0; i < moveLayerRed.Length; i++)
		{
			moveLayerRed[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
		}

		for (int i = 0; i < moveLayerGreen.Length; i++)
		{
			moveLayerGreen[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
		}

		for (int i = 0; i < moveLayerBlue.Length; i++)
		{
			moveLayerBlue[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
		}

		for (int i = 0; i < moveLayerCyan.Length; i++)
		{
			moveLayerCyan[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
		}

		for (int i = 0; i < moveLayerMagenta.Length; i++)
		{
			moveLayerMagenta[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
		}

		for (int i = 0; i < moveLayerYellow.Length; i++)
		{
			moveLayerYellow[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
		}

		for (int i = 0; i < moveLayerWhite.Length; i++)
		{
			moveLayerWhite[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
		}
        #endregion
    }

    public void ColorUpdate(string color, float colorValue, int layerNumber)
	{
        #region Atualizando cores
        if (color == "red")
		{
			for (int i = 0; i < moveLayerRed.Length; i++)
			{
				moveLayerRed[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, colorValue);
				moveLayerRed[i].layer = layerNumber;
			}
		}

		else if(color == "green")
		{
			for (int i = 0; i < moveLayerGreen.Length; i++)
			{
				moveLayerGreen[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, colorValue);
				moveLayerGreen[i].layer = layerNumber;
			}
		}

		else if(color == "blue")
		{
			for (int i = 0; i < moveLayerBlue.Length; i++)
			{
				moveLayerBlue[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, colorValue);
				moveLayerBlue[i].layer = layerNumber;
			}
		}

		else if(color == "cyan")
		{
			for (int i = 0; i < moveLayerCyan.Length; i++)
			{
				moveLayerCyan[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, colorValue);
				moveLayerCyan[i].layer = layerNumber;
			}
		}

		else if(color == "magenta")
		{
			for (int i = 0; i < moveLayerMagenta.Length; i++)
			{
				moveLayerMagenta[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, colorValue);
				moveLayerMagenta[i].layer = layerNumber;
			}
		}

		else if(color == "yellow")
		{
			for (int i = 0; i < moveLayerYellow.Length; i++)
			{
				moveLayerYellow[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, colorValue);
				moveLayerYellow[i].layer = layerNumber;
			}
		}

		else
		{
			for (int i = 0; i < moveLayerWhite.Length; i++)
			{
				moveLayerWhite[i].GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, colorValue);
				moveLayerWhite[i].layer = layerNumber;
			}
		}
        #endregion
    }

	public void ParticleEffectsUpdate(string color, bool active)
	{
		if(color == "red")
		{
			if (active)
			{
				for (int i = 0; i < backgroundRed.Length; i++)
				{
					backgroundRed[i].Play();
				}
			}
			else
			{
				for (int i = 0; i < backgroundRed.Length; i++)
				{
					backgroundRed[i].Stop();
				}
			}
		}

		if (color == "green")
		{
			if (active)
			{
				for (int i = 0; i < backgroundGreen.Length; i++)
				{
					backgroundGreen[i].Play();
				}
			}
			else
			{
				for (int i = 0; i < backgroundGreen.Length; i++)
				{
					backgroundGreen[i].Stop();
				}
			}
		}

		if (color == "blue")
		{
			if (active)
			{
				for (int i = 0; i < backgroundBlue.Length; i++)
				{
					backgroundBlue[i].Play();
				}
			}
			else
			{
				for (int i = 0; i < backgroundBlue.Length; i++)
				{
					backgroundBlue[i].Stop();
				}
			}
		}

		

	}

	public void CombinationsUpdate(string color, bool active)
	{
		if (color == "red")
		{
			if (active)
			{
				if (greenState == true && blueState == false)
				{
					//Yellow
					ColorUpdate("yellow", 1f, 8);

					yellowState = true;
					yellow.SetActive(true);
					yellow.layer = 8;

					for (int i = 0; i < backgroundYellow.Length; i++)
					{
						backgroundYellow[i].Play();
					}

				}
				else if (blueState == true && greenState == false)
				{
					//Magenta
					ColorUpdate("magenta", 1f, 8);

					magentaState = true;
					magenta.SetActive(true);
					magenta.layer = 8;

					for (int i = 0; i < backgroundMagenta.Length; i++)
					{
						backgroundMagenta[i].Play();
					}

				}
				else if (greenState == true && blueState == true)
				{
					//White
					ColorUpdate("yellow", 1f, 8);
					ColorUpdate("magenta", 1f, 8);
					ColorUpdate("white", 1f, 8);

					yellowState = true;
					yellow.SetActive(true);
					yellow.layer = 8;

					magentaState = true;
					magenta.SetActive(true);
					magenta.layer = 8;

					whiteState = true;
					white.SetActive(true);
					white.layer = 8;

					if (backgroundWhite.Length > 0)
					{
						for (int i = 0; i < backgroundWhite.Length; i++)
						{
							backgroundWhite[i].Play();
						}
					}
				}
			}

			else
			{
				ColorUpdate("yellow", .08f, 15);
				ColorUpdate("magenta", .08f, 14);
				ColorUpdate("white", .08f, 16);

				yellowState = false;
				yellow.layer = 15;

				magentaState = false;
				magenta.layer = 14;

				whiteState = false;
				white.layer = 16;

				if (backgroundYellow.Length > 0)
				{
					if (backgroundYellow[0].isPlaying)
					{
						for (int i = 0; i < backgroundYellow.Length; i++)
						{
							backgroundYellow[i].Stop();
						}
					}
				}

				if (backgroundMagenta.Length > 0)
				{
					if (backgroundMagenta[0].isPlaying)
					{
						for (int i = 0; i < backgroundMagenta.Length; i++)
						{
							backgroundMagenta[i].Stop();
						}
					}
				}

				if (backgroundWhite.Length > 0)
				{
					if (backgroundWhite[0].isPlaying)
					{
						for (int i = 0; i < backgroundWhite.Length; i++)
						{
							backgroundWhite[i].Stop();
						}
					}
				}

			}
		}

		if (color == "green")
		{
			if (active)
			{
				if (redState == true && blueState == false)
				{
					//Yellow
					ColorUpdate("yellow", 1f, 8);

					yellowState = true;
					yellow.SetActive(true);
					yellow.layer = 8;

					for (int i = 0; i < backgroundYellow.Length; i++)
					{
						backgroundYellow[i].Play();
					}
				}
				else if (blueState == true && redState == false)
				{
					//Cyan
					ColorUpdate("cyan", 1f, 8);

					cyanState = true;
					cyan.SetActive(true);
					cyan.layer = 8;

					for (int i = 0; i < backgroundCyan.Length; i++)
					{
						backgroundCyan[i].Play();
					}
				}
				else if (redState == true && blueState == true)
				{
					//White
					ColorUpdate("yellow", 1f, 8);
					ColorUpdate("cyan", 1f, 8);
					ColorUpdate("white", 1f, 8);

					yellowState = true;
					yellow.SetActive(true);
					yellow.layer = 8;

					cyanState = true;
					cyan.SetActive(true);
					cyan.layer = 8;

					whiteState = true;
					white.SetActive(true);
					white.layer = 8;

					if (backgroundWhite.Length > 0)
					{

						for (int i = 0; i < backgroundWhite.Length; i++)
						{
							backgroundWhite[i].Play();
						}
					}
				}
			}
			else
			{
				ColorUpdate("yellow", .08f, 15);
				ColorUpdate("cyan", .08f, 13);
				ColorUpdate("white", .08f, 16);

				yellowState = false;
				yellow.layer = 15;

				cyanState = false;
				cyan.layer = 13;

				whiteState = false;
				white.layer = 16;

				if (backgroundYellow.Length > 0)
				{
					if (backgroundYellow[0].isPlaying)
					{
						for (int i = 0; i < backgroundYellow.Length; i++)
						{
							backgroundYellow[i].Stop();
						}
					}
				}

				if (backgroundCyan.Length > 0)
				{
					if (backgroundCyan[0].isPlaying)
					{
						for (int i = 0; i < backgroundCyan.Length; i++)
						{
							backgroundCyan[i].Stop();
						}
					}
				}

				if (backgroundWhite.Length > 0)
				{
					if (backgroundWhite[0].isPlaying)
					{
						for (int i = 0; i < backgroundWhite.Length; i++)
						{
							backgroundWhite[i].Stop();
						}
					}
				}

			}
		}

		if (color == "blue")
		{
			if (active)
			{
				if (redState == true && greenState == false)
				{
					//Magenta
					ColorUpdate("magenta", 1f, 8);

					magentaState = true;
					magenta.SetActive(true);
					magenta.layer = 8;

					for (int i = 0; i < backgroundMagenta.Length; i++)
					{
						backgroundMagenta[i].Play();
					}
				}
				else if (greenState == true && redState == false)
				{
					//Cyan
					ColorUpdate("cyan", 1f, 8);

					cyanState = true;
					cyan.SetActive(true);
					cyan.layer = 8;

					for (int i = 0; i < backgroundCyan.Length; i++)
					{
						backgroundCyan[i].Play();
					}
				}
				else if (redState == true && greenState == true)
				{
					//White
					ColorUpdate("magenta", 1f, 8);
					ColorUpdate("cyan", 1f, 8);
					ColorUpdate("white", 1f, 8);

					magentaState = true;
					magenta.SetActive(true);
					magenta.layer = 8;

					cyanState = true;
					cyan.SetActive(true);
					cyan.layer = 8;

					whiteState = true;
					white.SetActive(true);
					white.layer = 8;

					if (backgroundWhite.Length > 0)
					{
						for (int i = 0; i < backgroundWhite.Length; i++)
						{
							backgroundWhite[i].Play();
						}
					}
				}
			}
			else
			{
				ColorUpdate("magenta", .08f, 14);
				ColorUpdate("cyan", .08f, 13);
				ColorUpdate("white", .08f, 16);

				magentaState = false;
				magenta.layer = 14;

				cyanState = false;
				cyan.layer = 13;

				whiteState = false;
				white.layer = 16;

				if (backgroundMagenta.Length > 0)
				{
					if (backgroundMagenta[0].isPlaying)
					{
						for (int i = 0; i < backgroundMagenta.Length; i++)
						{
							backgroundMagenta[i].Stop();
						}
					}
				}

				if (backgroundCyan.Length > 0)
				{
					if (backgroundCyan[0].isPlaying)
					{
						for (int i = 0; i < backgroundCyan.Length; i++)
						{
							backgroundCyan[i].Stop();
						}
					}
				}

				if (backgroundWhite.Length > 0)
				{
					if (backgroundWhite[0].isPlaying)
					{
						for (int i = 0; i < backgroundWhite.Length; i++)
						{
							backgroundWhite[i].Stop();
						}
					}
				}

			}
		}

	}//Fim do metodo
}//Fim do Script
