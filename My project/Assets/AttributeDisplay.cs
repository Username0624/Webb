using UnityEngine;
using UnityEngine.UI; // �ޤJ UnityEngine.UI �R�W�Ŷ�

public class AttributeDisplay : MonoBehaviour
{
    public int rebelliousness = 0; // �q�f��
    public int stress = 0;         // ���O��
    public int happiness = 0;      // ���ַP
    public int focus = 0;          // �M�`��

    public Text rebelliousnessText; // �Ω���ܫq�f�Ȫ�Text
    public Text stressText;         // �Ω�������O�Ȫ�Text
    public Text happinessText;      // �Ω���ܩ��ַP��Text
    public Text focusText;          // �Ω���ܱM�`�ת�Text

    void Start()
    {
        // ��ܪ�l�ƭ�
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
