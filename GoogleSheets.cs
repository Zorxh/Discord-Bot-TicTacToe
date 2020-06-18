﻿using DSharpPlus.Entities;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TicTacToeDiscordBot
{
    public class GoogleSheets
    {
        public string[] Scopes = { SheetsService.Scope.Spreadsheets };
        public string ApplicationName = "Discord Bot Server List";
        public string spreadsheetId = Bot.ReadFromJson("spreadsheetId"); // Insert your spreadsheetId here.
        public SheetsService SheetsService;

        public void InitSheetsApi()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Google Sheets API service.
            SheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            
        }

        public void UpdateData(List<DiscordGuild> servers)
        {
            // Define request parameters.
            string range = "Server List!A1";

            ValueRange valueRange = new ValueRange();
            valueRange.MajorDimension = "COLUMNS";

            List<object> oblist = new List<object>();
            

            for (int i = 0; i < servers.Count; i++)
            {
                oblist.Add(servers[i].Name);
            }

            valueRange.Values = new List<IList<object>> { oblist }; valueRange.Values = new List<IList<object>> { oblist };
            SpreadsheetsResource.ValuesResource.UpdateRequest update = SheetsService.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            UpdateValuesResponse result = update.Execute();

        }
    }
}
