using UnityEngine;
using System.Collections;

/// <summary>
/// Classe responsável pela órbita e rotação dos astros.
/// </summary>
public class Orbit : MonoBehaviour
{
	/// <summary>
	/// Centro da órbita.
	/// </summary>
	public Transform Center;

	/// <summary>
	/// Rotação em dias terrestres.
	/// </summary>
	public float RotationEarthDays;

	/// <summary>
	/// Rotação em relação a órbita terrestre.
	/// </summary>
	public float EarthOrbits;

	/// <summary>
	/// Escala de tempo.
	/// </summary>
	private float _timescale = 24 * 60 * 60; // 1 dia = 1 minuto

	/// <summary>
	/// Eixo para órbita.
	/// </summary>
	private Vector3 _orbitAxis;

	/// <summary>
	/// Rastro do planeta.
	/// </summary>
	private TrailRenderer _trail;

	void Start ()
	{
		//
		// Se não ouver Centro o eixo de rotação é pra cima, caso contrário é calculado em relação ao astro e o seu centro
		//
		if(Center)
		{
			_orbitAxis = Vector3.Cross(Center.position - transform.position , transform.forward);
		}
		else
		{
			_orbitAxis = Vector3.up;
		}

		_trail = GetComponent<TrailRenderer>();

		//
		// Controle de duração do rastro dos astros
		//
		if(_trail)
		{
			_trail.time = (1 / EarthOrbits) * ((365 * 24 * 60 * 60) / _timescale);

			if(this.name == "Moon")
			{
				_trail.time = (0.07480356f / EarthOrbits) * ((27 * 24 * 60 * 60) / _timescale) / 27f;
			}
		}
	}
	
	void Update ()
	{
		float revolutionAngle;

		//
		// Calcula o angulo de revolução (rotação em volta do próprio eixo)
		//
		if(RotationEarthDays == 0)
		{
			revolutionAngle = 0;
		}
		else
		{
			revolutionAngle = -(360 / (RotationEarthDays * 24 * 60 * 60)) * Time.deltaTime * _timescale;
		}

		float orbitAngle;

		//
		// Calcula o ângulo de órbita
		//
		if(EarthOrbits == 0)
		{
			orbitAngle = 0;
		}
		else
		{
			orbitAngle = -(360 / ((365 * 24 * 60 * 60) / EarthOrbits)) * Time.deltaTime * _timescale;
		}

		//
		// Translação do planeta
		//
		transform.Rotate(0, revolutionAngle, 0, Space.Self);

		if(Center)
		{
			//
			// Orbita em volta do centro
			//
			transform.RotateAround(Center.position, _orbitAxis, orbitAngle);

			//
			// Anula a rotação local gerada pela orbita para manter a inclinação do planeta correta
			//
			transform.Rotate(_orbitAxis, -orbitAngle, Space.World);
		}
	}

	/// <summary>
	/// Altera a escala de tempo.
	/// </summary>
	/// <param name="timeScale">Escala de tempo.</param>
	public void UpdateTimeScale(float timeScale)
	{
		_timescale = timeScale;
		
		_trail = GetComponent<TrailRenderer>();

		if(_trail)
		{
			//
			// Altera o tempo de duração do Trail para desaparecer assim que o planeta encosta na cauda.
			//
			_trail.time = (1 / EarthOrbits) * ((365 * 24 * 60 * 60) / _timescale);

			if(this.name == "Moon")
			{
				//
				// Valores específicos para a Lua (órbita com cálculo diferente)
				//
				_trail.time = (0.07480356f / EarthOrbits) * ((27 * 24 * 60 * 60) / _timescale) / 27f;
			}
		}
	}
}
