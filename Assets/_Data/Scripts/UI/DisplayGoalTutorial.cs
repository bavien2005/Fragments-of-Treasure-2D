using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGoalTutorial : DinoBehaviourScript
{
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIGoalTutorial.Instance.Open();
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIGoalTutorial.Instance.Close();
        }
    }
}
