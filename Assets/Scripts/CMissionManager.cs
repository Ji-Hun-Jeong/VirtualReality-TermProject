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

    public int itemCount = 5;
    private string currentItemName;

    void Start()
    {
    }

    void Update()
    {
    }

    void UpdateUI()
    {
        guideText1.text = "���� ��ư�� ������ ��������";
        guideText2.text = "������ ����������: ";
        itemCountText.text = itemCount.ToString();
        itemNameText.text = currentItemName;
    }

    public void SetMissionFlag(bool flag) { 
        missionFlag = flag;
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

    public void missionNext() {
        if (missionFlag)
        {
            if (itemCount > 0)
            {
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
}
