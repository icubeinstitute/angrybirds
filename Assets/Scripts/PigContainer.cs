using UnityEngine;
using TMPro;

public class PigContainer : MonoBehaviour
{
    [SerializeField] TMP_Text txtPigStats;
    [SerializeField] GameManager gameManager;

    int pigsTotal;
    int pigsDestroyed = 0;

    void Start()
    {
        pigsTotal = transform.childCount;
        DisplayPigStats();
    }

    public void OnPigDestroy()
    {
        pigsDestroyed++;
        DisplayPigStats();
        if(pigsDestroyed == pigsTotal)
        {
            gameManager.OnLevelFinish();
        }
    }

    void DisplayPigStats()
    {
        txtPigStats.text = $"{pigsDestroyed} / {pigsTotal}";
    }
}
