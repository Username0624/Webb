using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildStats : MonoBehaviour
{
    // �ݩʦr��A�ʺA�s�x�h���ݩ�
    private Dictionary<string, int> attributes = new Dictionary<string, int>();

    // �Ω���ܷ�e�ݩʭȪ� UI ����
    public Text attributesDisplay;

    void Start()
    {
        // ��l���ݩ�
        attributes["Rebelliousness"] = Random.Range(0, 101); // �q�f�� 0-100
        attributes["Stress"] = Random.Range(0, 101);        // ���O�� 0-100
        attributes["Happiness"] = Random.Range(0, 101);     // �ּ֭� 0-100
        attributes["Focus"] = Random.Range(0, 101);         // �M�`�� 0-100

        // ��s���
        UpdateAttributesDisplay();
    }

    /// <summary>
    /// ��s�ݩʭȨýT�O�Ȧb�d�򤺡C
    /// </summary>
    /// <param name="attributeName">�ݩʦW��</param>
    /// <param name="changeAmount">�ܤƶq�]�i�H�O���Ʃέt�ơ^</param>
    public void UpdateAttribute(string attributeName, int changeAmount)
    {
        if (attributes.ContainsKey(attributeName))
        {
            attributes[attributeName] += changeAmount;

            // �����ݩʭȦb 0-100 ����
            attributes[attributeName] = Mathf.Clamp(attributes[attributeName], 0, 100);

            // ��s���
            UpdateAttributesDisplay();
        }
        else
        {
            Debug.LogWarning($"�ݩ� '{attributeName}' ���s�b�A�L�k��s�C");
        }
    }

    /// <summary>
    /// ��s�ݩ���ܨ� UI�C
    /// </summary>
    private void UpdateAttributesDisplay()
    {
        if (attributesDisplay != null)
        {
            string displayText = "�Ĥl��e�ݩ�:\n";
            foreach (var attribute in attributes)
            {
                displayText += $"{attribute.Key}: {attribute.Value}\n";
            }
            attributesDisplay.text = displayText;
        }
    }

    /// <summary>
    /// �����e�ݩʭȡ]�p�ݶi�@�B�P�_�^�C
    /// </summary>
    /// <param name="attributeName">�ݩʦW��</param>
    /// <returns>�ݩʭ�</returns>
    public int GetAttribute(string attributeName)
    {
        if (attributes.ContainsKey(attributeName))
        {
            return attributes[attributeName];
        }
        else
        {
            Debug.LogWarning($"�ݩ� '{attributeName}' ���s�b�C");
            return 0;
        }
    }
}
