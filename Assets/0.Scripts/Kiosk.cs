using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MainMenuType
{
    FastFood,
    Pizza,
    China,
    Coffee,
    Korea,
    Chicken
}

public class Kiosk : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject datailMenuObj;
    [SerializeField] private GameObject titleObj;

    [SerializeField] private Transform titleParent;
    [SerializeField] private ItemTitle titlePrefab;
    [SerializeField] private Transform detailParent;
    [SerializeField] private GameObject detailPrefab;

    List<string> titleList = new List<string>();
    Dictionary<string, int> menuDic = new Dictionary<string, int>();

    private MainMenuType selectType = MainMenuType.FastFood;

    // Start is called before the first frame update
    void Start()
    {
        titleList.Clear();
        switch (selectType)
        {
            case MainMenuType.FastFood:
                string[] strs = {"햄버거", "음료", "스낵류", "소스", "아이스크림"};
                foreach (var item in strs)
                {
                    titleList.Add(item);
                }
                break;
            case MainMenuType.Pizza:
                break;
            case MainMenuType.China:
                break;
        }
        OnShowMain();
    }

    public void OnShowMain()
    {
        ShowMain(true);

        // 타이틀 셋팅
        for (int i = 0; i < titleList.Count; i++)
        {
            ItemTitle title = Instantiate(titlePrefab, titleParent);
            title.SetText(titleList[i]);
            title.name = titleList[i];

            Toggle toggle = title.GetComponent<Toggle>();
            toggle.group = titleParent.GetComponent<ToggleGroup>();
            toggle.onValueChanged.AddListener(delegate { OnToggle(toggle); });

            if (i == 0)
            {
                toggle.isOn = true;
            }
        }
    }
    public void OnShowDatail()
    {
        ShowMain(false);
    }

    public void ShowMain(bool isShow)
    {
        menuObj.SetActive(isShow);
        datailMenuObj.SetActive(!isShow);
        titleObj.SetActive(!isShow);
    }

    public void OnToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Debug.Log(toggle.name);
        }
    }
}
