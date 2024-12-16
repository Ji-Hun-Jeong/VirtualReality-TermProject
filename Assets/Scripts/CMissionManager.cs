using UnityEngine;
using UnityEngine.UI;

public class CMissionManager : MonoBehaviour
{
    public Text guideText1;
    public Text guideText2;
    public Text itemCountText;
    public Text itemNameText;

    public bool missionFlag = false;
    public CCompletePoint cp;

    private string[] itemNames = { "�����۽�", "�ݶ�", "���" };
    private int itemCount = 5;
    private string currentItemName;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && missionFlag)
        {
            if (itemCount > 0)
            {
                SetNewItemName();
                UpdateUI();
                itemCount--;
            }
            else if (itemCount == 0)
            {
                currentItemName = "ī���ͷ� ���ƿ�����";
                UpdateUI();

                cp.starting();
            }
        }
    }

    void SetNewItemName()
    {
        int randomIndex = Random.Range(0, itemNames.Length);
        currentItemName = itemNames[randomIndex];
    }

    void UpdateUI()
    {
        guideText1.text = "R�� ���� ���� ����";
        guideText2.text = "������ ����������: ";
        itemCountText.text = itemCount.ToString();
        itemNameText.text = currentItemName;
    }

    public void SetMissionFlag(bool flag) { 
        missionFlag = flag;
        SetNewItemName();
        UpdateUI();
        itemCount--;
    }

    public void InitText()
    {
        guideText1.text = "";
        guideText2.text = "";
        itemCountText.text = "";
        itemNameText.text = "";
    }
}