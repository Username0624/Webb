using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildStats : MonoBehaviour
{
    // 屬性字典，動態存儲多個屬性
    private Dictionary<string, int> attributes = new Dictionary<string, int>();

    // 用於顯示當前屬性值的 UI 元件
    public Text attributesDisplay;

    void Start()
    {
        // 初始化屬性
        attributes["Rebelliousness"] = Random.Range(0, 101); // 叛逆值 0-100
        attributes["Stress"] = Random.Range(0, 101);        // 壓力值 0-100
        attributes["Happiness"] = Random.Range(0, 101);     // 快樂值 0-100
        attributes["Focus"] = Random.Range(0, 101);         // 專注值 0-100

        // 更新顯示
        UpdateAttributesDisplay();
    }

    /// <summary>
    /// 更新屬性值並確保值在範圍內。
    /// </summary>
    /// <param name="attributeName">屬性名稱</param>
    /// <param name="changeAmount">變化量（可以是正數或負數）</param>
    public void UpdateAttribute(string attributeName, int changeAmount)
    {
        if (attributes.ContainsKey(attributeName))
        {
            attributes[attributeName] += changeAmount;

            // 限制屬性值在 0-100 之間
            attributes[attributeName] = Mathf.Clamp(attributes[attributeName], 0, 100);

            // 更新顯示
            UpdateAttributesDisplay();
        }
        else
        {
            Debug.LogWarning($"屬性 '{attributeName}' 不存在，無法更新。");
        }
    }

    /// <summary>
    /// 更新屬性顯示到 UI。
    /// </summary>
    private void UpdateAttributesDisplay()
    {
        if (attributesDisplay != null)
        {
            string displayText = "孩子當前屬性:\n";
            foreach (var attribute in attributes)
            {
                displayText += $"{attribute.Key}: {attribute.Value}\n";
            }
            attributesDisplay.text = displayText;
        }
    }

    /// <summary>
    /// 獲取當前屬性值（如需進一步判斷）。
    /// </summary>
    /// <param name="attributeName">屬性名稱</param>
    /// <returns>屬性值</returns>
    public int GetAttribute(string attributeName)
    {
        if (attributes.ContainsKey(attributeName))
        {
            return attributes[attributeName];
        }
        else
        {
            Debug.LogWarning($"屬性 '{attributeName}' 不存在。");
            return 0;
        }
    }
}
