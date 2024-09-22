using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendReport : MonoBehaviour
{
    [SerializeField] private float reportCoolDownTime;
    [SerializeField] private Transform sendReport;
    [SerializeField] private GameObject[] reports;
    private PlayerMovement _playerMovement;
    private Animator anim;
    private float _coolDownTimer = Mathf.Infinity;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // Update cooldown timer each frame
        _coolDownTimer += Time.deltaTime;

        // Check if the player can shoot
        if (Input.GetMouseButton(0) && _coolDownTimer > reportCoolDownTime && _playerMovement.canSendReports())
        {
            // Call the method to shoot one report
            SendTheReport();
        }
    }

    private void SendTheReport()
    {
        // Reset the cooldown timer
        _coolDownTimer = 0;

        // Find the next available inactive report in the pool
        int reportIndex = FindReport();

        // Only fire if an inactive report was found
        if (reportIndex != -1)
        {
            // Set position and activate the projectile
            reports[reportIndex].transform.position = sendReport.position;
            reports[reportIndex].GetComponent<Report>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
    }

    private int FindReport()
    {
        // Loop through the pool and return the index of the first inactive report
        for (int i = 0; i < reports.Length; i++)
        {
            if (!reports[i].activeInHierarchy)
            {
                return i;
            }
        }

        // Return -1 if no inactive report is available
        return -1;
    }
}