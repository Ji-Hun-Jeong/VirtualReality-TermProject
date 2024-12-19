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
        guideText1.text = "중지 버튼을 눌러서 물건집기";
        guideText2.text = "물건을 가져오세요: ";
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
                currentItemName = "카운터로 돌아오세요";
                UpdateUI();

                cp.starting();
            }
        }
    }
}
