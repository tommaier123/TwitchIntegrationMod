﻿using System.Collections.Generic;
using UnityEngine;
using UMod;
using Synth.mods.utils;
using System.IO;
using Synth.mods.info;
using TwitchLib.Client.Models;
using TwitchLib.Unity;
using System;
using TwitchLib.Client.Events;
using Synth.mods.interactions;
using Synth.mods.events;

namespace TwitchIntegrationScript
{
    public class TwitchIntegration : ModScript, ISynthRidersEvents, ISynthRidersInfo, ISynthRidersInteractions
    {
        public override void OnModLoaded()
        {
            GameObject obj = ModAssets.Instantiate<GameObject>("RequestButton_pre");
            TwitchBot.userText = ModAssets.Instantiate<GameObject>("UserText");
            log("TwitchColorMod loaded");
        }

        public void OnRoomLoaded()
        {
            RequestButton.ShowMe();
        }

        public void OnRoomUnloaded()
        {
            RequestButton.HideMe();
        }


        public override void OnModUnload()
        {
            TwitchBot.Disconnect();
            RequestButton.DestroyMe();
            log("TwitchColorMod unloaded");
        }

        public override void OnModUpdate()
        {

        }

        public void SetLoadedTracks(List<TrackData> tracks)
        {
            RequestButton.Tracks = tracks;

            TwitchBot.tracks = new List<string>();
            foreach (TrackData t in tracks)
            {
                TwitchBot.tracks.Add(t.name);
            }
        }

        public void SetLoadedStages(List<StageData> stages)
        {

        }

        public void SetSelectedTrackCallback(Action<int> callback)
        {
            RequestButton.SetSelectedTrackCallback = callback;
        }

        public void SetUserSelectedColors(Color leftHandColor, Color rightHandColor, Color oneHandSpecialColor, Color bothHandSpecialColor)
        {

        }

        public void SetCurrentSongSelected(int CurrentSong)
        {

        }

        public void SetUICanvasCallback(Action<GameObject> callback)
        {
            RequestButton.SetUICanvasCallback = callback;
            RequestButton.InitCanvasVRTK();
        }


        public void SetGameOverCallback(Action callback)
        {

        }

        public void SetRefreshCallback(Action<Action, bool> callback)
        {

        }

        public void SetFilterTrackCallback(Action<List<string>, Action, bool> callback)
        {

        }

        public void SetPlayTrackCallback(Action<int, int, int> callback)
        {

        }

        public void OnGameStageLoaded(TrackData trackData)
        {
            TwitchBot.inLevel = true;
        }

        public void OnGameStageUnloaded()
        {
            TwitchBot.inLevel = false;
        }

        public void OnScoreStageLoaded()
        {

        }

        public void OnScoreStageUnloaded()
        {

        }

        public void OnPointScored(PointsData pointsData)
        {

        }

        public void OnNoteFail(PointsData pointsData)
        {

        }

        public void OnSongFinished(SongFinishedData songFinishedData)
        {

        }

        public void OnSongFailed(TrackData trackData)
        {

        }

        public void log(string str)
        {
            //get file path
            var dataPath = Application.dataPath;
            var filePath = dataPath.Substring(0, dataPath.LastIndexOf('/')) + "/Novalog.txt";

            //write
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(str);
            }
        }

        public void SetLoseLifeCallback(Action callback)
        {
            TwitchBot.looseLifeCallback = callback;
        }

        public void SetSongModifier(Action<int[]> callback)
        {

        }

        public void SetSongPitchCallback(Action<float> callback)
        {
            TwitchBot.setPitchCallback = callback;
        }

        public void SetDisableScoreUploadCallback(Action callback)
        {
            TwitchBot.disableScoreCallback = callback;
        }
    }
}
