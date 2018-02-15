using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentSystemNavigation : MonoBehaviour 
{
	[Header("Pop up Panels")]
	[SerializeField] private GameObject talent_weaponPopup;
	[SerializeField] private GameObject talentSelectionPopup;

	[Header("Weapon Panel Text")]
	[SerializeField] private Text weaponTalentPointSpentText;
	[SerializeField] private Text weaponTalentPointsToSpendText;

	[Header("Talent Panel Text")]
	[SerializeField] private Text TalentPointSpentText;
	[SerializeField] private Text TalentPointsToSpendText;

    [Header("Talent Popup Variables")]
    [SerializeField] private GameObject confirmPopup;
    [SerializeField] private Text talentDescription;

	private int talentPointsSpentCount { get; set; }
	private int talenPointsToSpendCount { get; set; }

    public Text TalentDescritpion
    {
        get { return talentDescription; }
        set { talentDescription = value;}
    }

	private bool isActive;

	void Start()
	{
		talent_weaponPopup.SetActive(false);
		talentSelectionPopup.SetActive(false);

		talentPointsSpentCount = 0;
		talenPointsToSpendCount = 0;

		isActive = false;
	}

	void Update()
	{
		TalentActiveCheck ();

		if (Input.GetKey(KeyCode.Escape)) 
		{
			talent_weaponPopup.SetActive (false);
			talentSelectionPopup.SetActive (false);
		}
	}

	/*We still need to create a class to manage talent points,
	 * but as soon as that happens, 
	 * the UI can be updated using this script in TalentActiveCheck() method.
	 */

	/// <summary>
	/// Checks if the talent screens are open, so that talent counts can be updated
	/// </summary>
	void TalentActiveCheck()
	{
		if (isActive) 
		{
			weaponTalentPointSpentText.text = talentPointsSpentCount.ToString();
			weaponTalentPointsToSpendText.text = talenPointsToSpendCount.ToString();

			TalentPointSpentText.text = talentPointsSpentCount.ToString();
			TalentPointsToSpendText.text = talenPointsToSpendCount.ToString();
		}
	}

	/// <summary>
	/// Attach to button to open up the Weapon selection window for the talents.
	/// </summary>
	public void TalentButtonPressed()
	{
		talent_weaponPopup.SetActive(true);
		talentSelectionPopup.SetActive(false);

		isActive = true;
	}

	/// <summary>
	/// Attach to button to open up the Weapon selection window for the talents. Required data for set weapon can be Instantiated here.
	/// </summary>
	public void WeaponOneSelectionPressed()
	{
		talent_weaponPopup.SetActive(false);
		talentSelectionPopup.SetActive(true);

		//Write Instantiate code below, inside if statements
	}

	/// <summary>
	/// Attach to button to open up the Weapon selection window for the talents. Required data for set weapon can be Instantiated here.
	/// </summary>
	public void WeaponTwoSelectionPressed()
	{
		talent_weaponPopup.SetActive(false);
		talentSelectionPopup.SetActive(true);

		//Write Instantiate code below, inside if statements
	}

	/// <summary>
	/// Attach to button to open up the Weapon selection window for the talents. Required data for set weapon can be Instantiated here.
	/// </summary>
	public void WeaponThreeSelectionPressed()
	{
		talent_weaponPopup.SetActive(false);
		talentSelectionPopup.SetActive(true);

		//Write Instantiate code below, inside if statements
	}

	/// <summary>
	/// Attach to button to open up the Weapon selection window for the talents. Required data for set weapon can be Instantiated here.
	/// </summary>
	public void WeaponFourSelectionPressed()
	{
		talent_weaponPopup.SetActive(false);
		talentSelectionPopup.SetActive(true);

		//Write Instantiate code below, inside if statements
	}

	/// <summary>
	/// Attach to button to open up the Weapon selection window for the talents. Required data for set weapon can be Instantiated here.
	/// </summary>
	public void WeaponFiveSelectionPressed()
	{
		talent_weaponPopup.SetActive(false);
		talentSelectionPopup.SetActive(true);

		//Write Instantiate code below, inside if statements
	}

    /// <summary>
    /// Activates Talent Description popup
    /// Sets text to required info
    /// </summary>
    public void TalentSelection()
    {
        confirmPopup.SetActive(true);
        talentDescription.text = "CALL TEXT HERE!!!";
    }

    /// <summary>
    /// Deactivates Confirm Popup
    /// Add confirmation code here
    /// </summary>
    public void ConfirmTalent()
    {
        confirmPopup.SetActive(false);
    }

    /// <summary>
    /// Deactivates Confirm Popup
    /// </summary>
    public void ConfirmCancel()
    {
        confirmPopup.SetActive(false);
    }

    public void TalentBackButtonPressed()
	{
		talent_weaponPopup.SetActive(true);
		talentSelectionPopup.SetActive(false);
	}

	public void WeaponBackButtonPressed()
	{
		talent_weaponPopup.SetActive(false);
		isActive = false;
	}
}
