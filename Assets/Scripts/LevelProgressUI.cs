using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgressUI : MonoBehaviour
{
    // currentLevelTextUI suanda oldugumuz bolumun sayisi | nextLevelTextUI bir sonraki bolumun sayisi
    [Header("UI references :")] [SerializeField]
    private Image fillImageUI;
    [SerializeField] private TextMeshProUGUI currentLevelTextUI;
    [SerializeField] private TextMeshProUGUI nextLevelTextUI;

    // dinamik pozisyonlar
    [Header("Player & Endline references :")]
    [SerializeField] private Transform endLineTransform;
    [SerializeField]private Transform playerTransform;
    
    private Vector3 endLinePosition;

    //fullDistance oyuncu ile bitis cizgisinin varsayilan uzakligi
    private float fullDistance;

    private void Start()
    {
        endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }

    public void SetLevelTexts(int level)
    {
        currentLevelTextUI.text = level.ToString();
        nextLevelTextUI.text = (level + 1).ToString();
    }

    private float GetDistance()
    {
        //EN SON
        return Vector3.Distance(playerTransform.position, endLinePosition);
    }

    private void UpdateProgressFill(float value)
    {
        fillImageUI.fillAmount = value;
    }

    private void Update()
    {
        if (playerTransform.position.z< endLinePosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
            UpdateProgressFill(progressValue);
        }
    }
}