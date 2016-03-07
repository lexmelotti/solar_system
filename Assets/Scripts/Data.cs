using UnityEngine;
using System.Collections;

/// <summary>
/// Dados do astro. (Retirados do site da NASA)
/// </summary>
public class Data : MonoBehaviour
{
	public new string name;
	
	public string orbit;

	public string earthOrbit;

	public string radius;

	public string earthRadius;

	public string mass;

	public string earthMass;

	public string gravity;

	public string earthGravity;

	public string rotation;

	public string temperature;

	/// <summary>
	/// Possui dados de temperatura na superfície?
	/// </summary>
	public bool surfaceTemperature;
}
