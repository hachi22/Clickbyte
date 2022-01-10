using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class GPHAchievements : MonoBehaviour
{
    [SerializeField] NumberController bits;

    private void Update()
    {
        switch (bits.currentBits)
        {
            case 100000f:
                Get100000Bits();
                break;
            case 1000000f:
                GetAMillionBits();
                break;
            case 1000000000f:
                GetABillionBits();
                break;
            case 1000000000000000000000000f:
                GetAQuadrillionBits();
                break;

        }
    }
    public void openAchievementPanel()
    {
        Social.ShowAchievementsUI();
    }

    public void Tap10Times()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_tapping_begginer, 1, null);
    }

    public void UnlockShop()
    {
        Social.ReportProgress(GPGSIds.achievement_shopping, 100f, null);
    }

    public void UnlockCredits()
    {
        Social.ReportProgress(GPGSIds.achievement_a_pretty_short_credits, 100f, null);
    }

    public void Do10000Taps()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_getting_bits, 1, null);
    }

    public void Get100000Bits()
    {
        Social.ReportProgress(GPGSIds.achievement_more_and_more_bits, 100f, null);
    }

    public void GetAMillionBits()
    {
        Social.ReportProgress(GPGSIds.achievement_a_million, 100f, null);
    }

    public void GetABillionBits()
    {
        Social.ReportProgress(GPGSIds.achievement_a_billion, 100f, null);
    }

    public void GetAQuadrillionBits()
    {
        Social.ReportProgress(GPGSIds.achievement_more_bits_than_elon_musk, 100f, null);
    }

    public void Get10Missions()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_begginer_hacker, 1, null);
    }

    public void Get50Missions()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_senior_hacker, 1, null);
    }

    public void Get100Missions()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_pro_hacker, 1, null);
    }

    public void Rebirth1Time()
    {
        Social.ReportProgress(GPGSIds.achievement_i_got_coins__but_at_what_cost, 100f, null);
    }

    public void GetThePowerOfLove()
    {
        Social.ReportProgress(GPGSIds.achievement_the_power_of_love, 100f, null);
    }

    public void Get1Mission()
    {
        Social.ReportProgress(GPGSIds.achievement_my_first_mission, 100f, null);
    }

    public void Get1Skin()
    {
        Social.ReportProgress(GPGSIds.achievement_my_first_skin, 100f, null);
    }

    public void Use20TimesGachaPowerUp()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_i_can_feel_the_power, 1, null);
    }

    public void FinishTutorial()
    {
        Social.ReportProgress(GPGSIds.achievement_tutorial_completed, 100f, null);
    }

}
