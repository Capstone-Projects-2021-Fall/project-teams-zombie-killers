using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum AchievementType
{
    ZKS_TEST,
    ZKS_DEFENDER,
    ZKS_FOREHORSEMAN,
    ZKS_TROPHY,
    ZKS_CACTUS
}

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager achievementManagerInstance;

    [System.Serializable]
    public class Achievement
    {
        public Sprite icon;
        public string display;
        public string description;
        public AchievementType ID;
        public int current;
        public int goal;
        public bool unlocked;
        public bool hidden; //optional hidden attribute
    }

    public GameObject achievementUnlockedNotif;
    public GameObject achievementObj;

    [SerializeField]
    public Achievement[] achievements;

    private void Awake()
    {
        achievementManagerInstance = this;
    }

    void Start()
    {
        LoadAchievementData();
        achievementUnlockedNotif = GameObject.Find("AchievementUnlocked");
    }

    public void AddAchievementProgress(AchievementType ID, int value)
    {
        Achievement achievement = achievements.FirstOrDefault(x => x.ID == ID);

        if (!achievement.unlocked)
        {
            achievement.current += value;

            if(achievement.current >= achievement.goal)
            {
                achievement.current = achievement.goal;
                achievement.unlocked = true;
                ShowUnlockedTic(achievement);
                Debug.Log("Unlocked Achievement: " + achievement.display);
            }
            SaveAchievementData(achievement.ID);
        }
    }

    public void ShowUnlockedTic(Achievement achievement)
    {
        achievementUnlockedNotif.transform.Find("UI").gameObject.SetActive(true);
        GameObject achUnlUIHolder = achievementUnlockedNotif.transform.Find("UI").gameObject;

        Image icon = achUnlUIHolder.transform.Find("AchievementIcon").GetComponent<Image>();
        icon.sprite = achievement.icon;

        Text nameText = achUnlUIHolder.transform.Find("AchievementName").GetComponent<Text>();
        nameText.text = achievement.display;

        Text descText = achUnlUIHolder.transform.Find("AchievementDescription").GetComponent<Text>();
        descText.text = achievement.description;

        achievementUnlockedNotif.GetComponent<Animator>().SetTrigger("Unlocked");
    }

    public void PopulateAchievementList(Transform parent)
    {
        if(parent.childCount > 0)
        {
            foreach(Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }

        foreach(Achievement achievement in achievements)
        {
            GameObject achievementObject = Instantiate(achievementObj, parent);

            Text achName = achievementObject.transform.Find("AchievementName").GetComponent<Text>();
            achName.text = achievement.display;

            Text achDesc = achievementObject.transform.Find("AchievementDescription").GetComponent<Text>();
            achDesc.text = achievement.description;

            Text achProgDisp = achievementObject.transform.Find("AchievementProgress").GetComponent<Text>();
            achProgDisp.text = achievement.current + "/" + achievement.goal;

            Image achIcon = achievementObject.transform.Find("AchievementIcon").GetComponent<Image>();
            achIcon.sprite = achievement.icon;

            Slider achProgBar = achievementObject.transform.Find("AchievementProgressBar").GetComponent<Slider>();
            achProgBar.maxValue = achievement.goal;
            achProgBar.value = achievement.current;

            Image background = achievementObject.transform.Find("Background").GetComponent<Image>();

            GameObject hiddenObj = achievementObject.transform.Find("Hidden").transform.Find("HiddenUI").gameObject;
            if (achievement.hidden)
                hiddenObj.SetActive(true);
            if (achievement.unlocked)
            {
                hiddenObj.SetActive(false);
                achName.color = Color.yellow;
                background.GetComponent<Outline>().effectColor = Color.yellow;
            }
        }
    }

    public void LoadAchievementData()
    {
        foreach(Achievement achievement in achievements)
        {
            achievement.current = GetAchievementPref("current", achievement.ID);
            achievement.unlocked = (GetAchievementPref("unlocked", achievement.ID) == 1) ? true : false;
        }
    }

    public void SaveAchievementData(AchievementType achID)
    {
        Achievement achievement = achievements.FirstOrDefault(x => x.ID == achID);

        SetAchievementPref("current", achievement.ID, achievement.current);
        SetAchievementPref("unlocked", achievement.ID, (achievement.unlocked == true) ? 1 : 0);
    }

    public int GetAchievementPref(string type, AchievementType achID)
    {
        return PlayerPrefs.GetInt(achID + "_" + type.ToUpper());
    }

    public void SetAchievementPref(string type, AchievementType achID, int value)
    {
        PlayerPrefs.SetInt(achID + "_" + type.ToUpper(), value);
    }
}
