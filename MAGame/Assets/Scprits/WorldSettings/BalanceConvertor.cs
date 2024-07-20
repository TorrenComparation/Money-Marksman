using UnityEngine;

public class BalanceConvertor : MonoBehaviour
{
    public static string ConvertMoney(float money)
    {
        if (money >= 1_000_000_000_000)
        {
            return $"{money / 1_000_000_000_000.0:F1}T";
        }
        else if (money >= 1_000_000_000)
        {
            return $"{money / 1_000_000_000.0:F1}B";
        }
        else if (money >= 1_000_000)
        {
            return $"{money / 1_000_000.0:F1}M";
        }
        else
        {
            return money.ToString();
        }
    }
}
