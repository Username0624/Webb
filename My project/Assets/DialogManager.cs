using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public InputField dialogInputField;  // 玩家輸入框
    public Button sendButton;           // 傳送按鈕
    public Text dialogDisplayText;      // 對話顯示框
    public AttributeDisplay attributeDisplay; // 屬性顯示管理

    private int dialogCount = 0;
    private const int maxDialogCount = 10; // 最大對話次數

    void Start()
    {
        sendButton.onClick.AddListener(ProcessDialog);
    }

    public void ProcessDialog()
    {
        string playerInput = dialogInputField.text;

        if (!string.IsNullOrEmpty(playerInput))
        {
            dialogDisplayText.text += $"\n[我]: {playerInput}";
            dialogInputField.text = ""; // 清空輸入框

            if (dialogCount >= maxDialogCount)
            {
                dialogDisplayText.text += "\n[?]: 已達到最大對話次數！";
                return;
            }

            AnalyzeDialog(playerInput);
            dialogCount++;
        }
    }

    private void AnalyzeDialog(string input)
    {
        if (attributeDisplay == null)
        {
            Debug.LogError("AttributeDisplay is not assigned!");
            return;
        }

        // 進行內容分析，判定屬性增減
        if (input.Contains("no") || input.Contains("I don't want"))
        {
            attributeDisplay.UpdateAttribute("rebelliousness", 2);
            dialogDisplayText.text += "\n[?]: Because of rebellion, rebelliousness +2.";
        }

        if (input.Contains("tired") || input.Contains("I can't do it"))
        {
            attributeDisplay.UpdateAttribute("stress", 3);
            dialogDisplayText.text += "\n[?]: Due to stress, stress +3.";
        }

        if (input.Contains("I'm happy") || input.Contains("That's awesome"))
        {
            attributeDisplay.UpdateAttribute("happiness", 5);
            dialogDisplayText.text += "\n[?]: Because of happiness, happiness +5.";
        }

        if (input.Contains("focused") || input.Contains("I will work hard"))
        {
            attributeDisplay.UpdateAttribute("focus", 3);
            dialogDisplayText.text += "\n[?]: Due to focus, focus +3.";
        }
    }
}
