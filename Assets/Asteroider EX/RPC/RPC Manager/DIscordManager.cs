using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIscordManager : MonoBehaviour
{
    public long timeStarted;
    private Discord.Discord discord;
    private bool discordIniciado = false;

    void Start()
    {
        try
        {
            discord = new Discord.Discord(
                1390349817359896639, 
                (ulong)Discord.CreateFlags.NoRequireDiscord
            );

            timeStarted = System.DateTimeOffset.Now.ToUnixTimeSeconds();
            ChangeActivity();
            discordIniciado = true;

            Debug.Log("Discord RPC iniciado com sucesso!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Falha ao iniciar o Discord RPC: " + e.Message);
        }
    }

    void OnDisable()
    {
        if (discordIniciado && discord != null)
        {
            discord.Dispose();
            Debug.Log("Discord RPC encerrado.");
        }
    }

    public void ChangeActivity()
    {
        if (!discordIniciado || discord == null) return;

        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Jogando",
            Details = "Capturando as Orbes",
            Assets = {
                LargeImage = "icon_rpc",
                LargeText = "Mega Asteroider Ex",
            },
            Timestamps = {
                Start = timeStarted
            },
            Party = {
                Id = "ae488379-351d-4a4f-ad32-2b9b01c91657",
                Size = {
                    CurrentSize = 0,
                    MaxSize = 0
                }
            }
        };

        activityManager.UpdateActivity(activity, (res) =>
        {
            Debug.Log("Discord Activity atualizada! Resultado: " + res);
        });
    }

    void Update()
    {
        if (discordIniciado && discord != null)
        {
            discord.RunCallbacks();
        }
    }
}
