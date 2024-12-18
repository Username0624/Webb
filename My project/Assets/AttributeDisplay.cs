using UnityEngine;
using UnityEngine.UI; // 引入 UnityEngine.UI 命名空間

public class AttributeDisplay : MonoBehaviour
{
    public int rebelliousness = 0; // 叛逆值
    public int stress = 0;         // 壓力值
    public int happiness = 0;      // 幸福感
    public int focus = 0;          // 專注度

    public Text rebelliousnessText; // 用於顯示叛逆值的Text
    public Text stressText;         // 用於顯示壓力值的Text
    public Text happinessText;      // 用於顯示幸福感的Text
    public Text focusText;          // 用於顯示專注度的Text

    void Start()
    {
        // 顯示初始化值
        UpdateAllAttributes();
    }

    public void UpdateAttribute(string attribute, int change)
    {
        switch (attribute)
        {
            case "rebelliousness":
                rebelliousness += change;
                break;
            case "stress":
                stress += change;
                break;
            case "happiness":
                happiness += change;
                break;
            case "focus":
                focus += change;
                break;
            default:
                Debug.LogWarning("Attribute not recognized.");
                return;
        }

        UpdateAllAttributes();
    }

    private void UpdateAllAttributes()
    {
        rebelliousnessText.text = "Rebelliousness: " + rebelliousness;
        stressText.text = "Stress: " + stress;
        happinessText.text = "Happiness: " + happiness;
        focusText.text = "Focus: " + focus;
    }
}
