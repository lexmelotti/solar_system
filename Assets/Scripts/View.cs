using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Controles de View.
/// </summary>
public class View : MonoBehaviour
{
	/// <summary>
	/// Nome do astro
	/// </summary>
	public Text Name;

	/// <summary>
	/// Informações do astro.
	/// </summary>
	public Text Info;

	/// <summary>
	/// Ativa um Panel.
	/// </summary>
	/// <param name="panel">Panel.</param>
	public void ActivatePanel(CanvasGroup panel)
	{
		panel.alpha = 1;
		panel.interactable = true;
		panel.blocksRaycasts = true;
	}

	/// <summary>
	/// Desativa um Panel.
	/// </summary>
	/// <param name="panel">Panel.</param>
	public void DeactivatePanel(CanvasGroup panel)
	{
		panel.alpha = 0;
		panel.interactable = false;
		panel.blocksRaycasts = false;
	}

	/// <summary>
	/// Apresenta dos dados do planeta.
	/// </summary>
	/// <param name="data">Data.</param>
	public void PlanetView(Data data)
	{
		Name.text = data.name;
		Info.text = "<size=24>Órbita Solar</size>\n<i><color=\"#999999\">" + data.orbit + " m/s\n" + data.earthOrbit + " x Terra</color></i>\n\n" +
			"<size=24>Raio Equatorial</size>\n<i><color=\"#999999\">"+ data.radius +" km\n"+ data.earthRadius +" x Terra</color></i>\n\n" +
			"<size=24>Massa</size>\n<i><color=\"#999999\">"+ data.mass +" kg\n"+ data.earthMass +" x Terra</color></i>\n\n" +
			"<size=24>Gravidade na Superfície</size>\n<i><color=\"#999999\">"+ data.gravity +" m/s²\n"+ data.earthGravity +" x Terra</color></i>\n\n" +
			"<size=24>Período de Rotação</size>\n<i><color=\"#999999\">"+ data.rotation +" Dias Terrestres</color></i>\n\n" +
			"<size=24>Temperatura " + (data.surfaceTemperature ? "na Superfície" : "Efetiva") + "</size>\n<i><color=\"#999999\">"+ data.temperature +" °C</color></i>";
	}

	/// <summary>
	/// Apresenta os dados do Sol.
	/// </summary>
	/// <param name="data">Data.</param>
	public void SunView(Data data)
	{
		Name.text = data.name;
		Info.text = "<size=24>Raio Equatorial</size>\n<i><color=\"#999999\">"+ data.radius +" km\n"+ data.earthRadius +" x Terra</color></i>\n\n" +
			"<size=24>Massa</size>\n<i><color=\"#999999\">"+ data.mass +" kg\n"+ data.earthMass +" x Terra</color></i>\n\n" +
			"<size=24>Gravidade na Superfície</size>\n<i><color=\"#999999\">"+ data.gravity +" m/s²\n"+ data.earthGravity +" x Terra</color></i>\n\n" +
			"<size=24>Período de Rotação</size>\n<i><color=\"#999999\">"+ data.rotation +" Dias Terrestres</color></i>\n\n" +
			"<size=24>Temperatura na Superfície</size>\n<i><color=\"#999999\">"+ data.temperature +" °C</color></i>";
	}

	/// <summary>
	/// Apresenta os dados da Terra.
	/// </summary>
	/// <param name="data">Data.</param>
	public void EarthView(Data data)
	{
		Name.text = data.name;
		Info.text = "<size=24>Órbita Solar</size>\n<i><color=\"#999999\">" + data.orbit + " m/s</color></i>\n\n" +
			"<size=24>Raio Equatorial</size>\n<i><color=\"#999999\">"+ data.radius +" km</color></i>\n\n" +
			"<size=24>Massa</size>\n<i><color=\"#999999\">"+ data.mass +" kg</color></i>\n\n" +
			"<size=24>Gravidade na Superfície</size>\n<i><color=\"#999999\">"+ data.gravity +" m/s²</color></i>\n\n" +
			"<size=24>Período de Rotação</size>\n<i><color=\"#999999\">"+ data.rotation +" Horas</color></i>\n\n" +
			"<size=24>Temperatura na Superfície</size>\n<i><color=\"#999999\">"+ data.temperature +" °C</color></i>";
	}

	/// <summary>
	/// Apresenta os dados da Lua.
	/// </summary>
	/// <param name="data">Data.</param>
	public void MoonView(Data data)
	{
		Name.text = data.name;
		Info.text = "<size=24>Órbita Terrestre</size>\n<i><color=\"#999999\">" + data.earthOrbit + " Dias Terrestres</color></i>\n\n" +
			"<size=24>Raio Equatorial</size>\n<i><color=\"#999999\">"+ data.radius +" km\n"+ data.earthRadius +" x Terra</color></i>\n\n" +
			"<size=24>Massa</size>\n<i><color=\"#999999\">"+ data.mass +" kg\n"+ data.earthMass +" x Terra</color></i>\n\n" +
			"<size=24>Gravidade na Superfície</size>\n<i><color=\"#999999\">"+ data.gravity +" m/s²\n"+ data.earthGravity +" x Terra</color></i>\n\n" +
			"<size=24>Período de Rotação</size>\n<i><color=\"#999999\">"+ data.rotation +" Dias Terrestres</color></i>\n\n" +
			"<size=24>Temperatura na Superfície</size>\n<i><color=\"#999999\">"+ data.temperature +" °C</color></i>";
	}
}
