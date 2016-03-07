using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

/// <summary>
/// Classe de controle de camera e tempo.
/// </summary>
public class Control : MonoBehaviour
{
	/// <summary>
	/// Lista do transform dos astros.
	/// </summary>
	public List<Transform> Targets;

	/// <summary>
	/// Alvo atual da câmera
	/// </summary>
	private Transform currentTarget;

	/// <summary>
	/// Posição prévia do alvo.
	/// </summary>
	private Vector3 previousTargetPosition;

	/// <summary>
	/// Nível de Zoom.
	/// </summary>
	private float zoomLevel = 1.5f;

	/// <summary>
	/// Efeito de foco seletivo.
	/// </summary>
	private DepthOfField blurEffect;

	/// <summary>
	/// Abertura para efeito de foco seletivo.
	/// </summary>
	private float aperture = 0f;

	/// <summary>
	/// Classe de view.
	/// </summary>
	private View view;

	void Start()
	{
		//
		// Inicializa o alvo inicial da câmera e efeito de foco
		//
		currentTarget = Targets[0];
		previousTargetPosition = currentTarget.position;
		transform.LookAt(currentTarget);
		blurEffect = GetComponent<DepthOfField>();

		//
		// Inicializa as informações dos astros apresentada
		//
		view = GetComponent<View>();
		view.SunView(currentTarget.GetComponent<Data>());
	}

	void LateUpdate()
	{
		//
		// Fecha aplicação com Esc
		//
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		//
		// Para cada tecla numérica (0~1 e -) altera o alvo da câmera e os dados apresentados sobre o astro alvo
		//
		if(Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
		{
			currentTarget = Targets[0];
			previousTargetPosition = currentTarget.position;

			//
			// Sem foco seletivo quando estivermos vendo o Sol para vizualizar melhor o sistema solar completo.
			//
			aperture = 0f;

			view.SunView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
			currentTarget = Targets[1];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		{
			currentTarget = Targets[2];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		{
			currentTarget = Targets[3];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.EarthView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
		{
			currentTarget = Targets[4];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
		{
			currentTarget = Targets[5];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
		{
			currentTarget = Targets[6];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
		{
			currentTarget = Targets[7];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
		{
			currentTarget = Targets[8];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
		{
			currentTarget = Targets[9];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.PlanetView(currentTarget.GetComponent<Data>());
		}
		else if(Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			currentTarget = Targets[10];
			previousTargetPosition = currentTarget.position;
			aperture = 0.5f;

			view.MoonView(currentTarget.GetComponent<Data>());
		}

		//
		// Com o botão pressionado rotaciona a camera em torno do alvo
		//
		if(Input.GetMouseButton(0))
		{
			transform.RotateAround(currentTarget.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * 200);
			transform.RotateAround(currentTarget.position, Vector3.Cross((currentTarget.position - transform.position), transform.up) , Input.GetAxis("Mouse Y") * Time.deltaTime * 200);
		}

		//
		// Atualiza o nível de Zoom baseado no Scroll do mouse
		//
		zoomLevel = zoomLevel - Input.mouseScrollDelta.y * 0.1f;

		//
		// Atualiza o valor da abertura do efeito de foco seletivo com um Lerp para melhor efeito visual
		//
		blurEffect.aperture = Mathf.Lerp(blurEffect.aperture, aperture, Time.deltaTime);

		//
		// Calcula a variação de posição do alvo desde o último update
		//
		Vector3 deltaPosition = currentTarget.position - previousTargetPosition;
		previousTargetPosition = currentTarget.position;

		//
		// Calcula nova posião da câmera com um Lerp para melhor efeito visual
		// Lerp se passa entre a nova posição atualizada (com delta de movimento) e a posição final desejada calculada da seguinte forma:
		// posição atual do alvo + vetor direção câmera/alvo * distância de zoom baseada na escala do astro
		//
		transform.position = Vector3.Lerp(transform.position + deltaPosition, currentTarget.position + (transform.position - currentTarget.position).normalized * (currentTarget.localScale.x * zoomLevel), Time.deltaTime);

		//
		// Calcula a distância focal: diferença entre a posição da câmera e do alvo
		//
		blurEffect.focalLength = (transform.position - currentTarget.position).magnitude;

		//
		// Olha para o alvo
		//
		transform.LookAt(currentTarget);
	}

	/// <summary>
	/// Altera a escala de tempo de todos os astros.
	/// </summary>
	/// <param name="scale">Nova escala.</param>
	public void setTimeScale(float scale)
	{
		foreach(Transform aux in Targets)
		{
			aux.GetComponent<Orbit>().UpdateTimeScale(scale);
		}
	}

	/// <summary>
	/// Fecha a aplicação.
	/// </summary>
	public void Quit()
	{
		Application.Quit();
	}
}
