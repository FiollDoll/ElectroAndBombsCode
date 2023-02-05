using Discord;
using UnityEngine;

public class discord : MonoBehaviour
{
    [SerializeField] long applicationID;
    [SerializeField] private string details,  state, largeImage, largeText;

    [SerializeField] long time;

    [SerializeField] Discord.Discord ds;

    [SerializeField] private map _scriptMap;
    [SerializeField] private player _scriptPlayer;

    void Start()
    {
        ds = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        UpdateStatus();
    }

    void Update()
    {
        try
        {
            ds.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate() 
    {
        UpdateStatus();
    }

    void UpdateStatus()
    {
        try
        {
            var activityManager = ds.GetActivityManager();
            var activity = new Discord.Activity
            {
                Details = $"Осталось времени: {Mathf.Round(_scriptPlayer._timer)}",
                State = $"Пройдено мини игр: {_scriptMap.readyGames}",
                Assets = 
                {
                    LargeImage = largeImage,
                    LargeText = largeText
                },
                Timestamps =
                {
                    Start = time
                }
            };

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok) Debug.LogWarning("Failed connecting to Discord!");
            });
        }
        catch
        {
            Destroy(gameObject);
        }
    }
}
