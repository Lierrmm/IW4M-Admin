﻿using System;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

using SharedLibraryCore.Objects;
using static SharedLibraryCore.Server;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using static SharedLibraryCore.RCon.StaticHelpers;
using System.Runtime.InteropServices;

namespace SharedLibraryCore
{
    public static class Utilities
    {
        public static string OperatingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar;
        public static readonly Task CompletedTask = Task.FromResult(false);

        //Get string with specified number of spaces -- really only for visual output
        public static String GetSpaces(int Num)
        {
            String SpaceString = String.Empty;
            while (Num > 0)
            {
                SpaceString += ' ';
                Num--;
            }

            return SpaceString;
        }

        //Remove words from a space delimited string
        public static String RemoveWords(this string str, int num)
        {
            if (str == null || str.Length == 0)
                return "";

            String newStr = String.Empty;
            String[] tmp = str.Split(' ');

            for (int i = 0; i < tmp.Length; i++)
            {
                if (i >= num)
                    newStr += tmp[i] + ' ';
            }

            return newStr;
        }

        public static List<Player> PlayersFromStatus(string[] Status)
        {
            List<Player> StatusPlayers = new List<Player>();

            foreach (String S in Status)
            {
                String responseLine = S.Trim();

                if (Regex.Matches(responseLine, @"\d+$", RegexOptions.IgnoreCase).Count > 0 && responseLine.Length > 72) // its a client line!
                {
                    String[] playerInfo = responseLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int cID = -1;
                    int Ping = -1;
                    Int32.TryParse(playerInfo[2], out Ping);
                    String cName = Encoding.UTF8.GetString(Encoding.Convert(Encoding.UTF7, Encoding.UTF8, Encoding.UTF7.GetBytes(StripColors(responseLine.Substring(46, 18)).Trim())));
                    long npID = Regex.Match(responseLine, @"([a-z]|[0-9]){16}", RegexOptions.IgnoreCase).Value.ConvertLong();
                    int.TryParse(playerInfo[0], out cID);
                    var regex = Regex.Match(responseLine, @"\d+\.\d+\.\d+.\d+\:\d{1,5}");
#if DEBUG
                    Ping = 1;
#endif

                    int cIP = regex.Value.Split(':')[0].ConvertToIP();
                    regex = Regex.Match(responseLine, @"[0-9]{1,2}\s+[0-9]+\s+");
                    int score = Int32.Parse(regex.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    Player P = new Player() { Name = cName, NetworkId = npID, ClientNumber = cID, IPAddress = cIP, Ping = Ping, Score = score };
                    StatusPlayers.Add(P);
                }
            }

            return StatusPlayers;
        }

        public static Player.Permission MatchPermission(String str)
        {
            String lookingFor = str.ToLower();

            for (Player.Permission Perm = Player.Permission.User; Perm < Player.Permission.Console; Perm++)
                if (lookingFor.Contains(Perm.ToString().ToLower()))
                    return Perm;

            return Player.Permission.Banned;
        }

        /// <summary>
        /// Remove all IW Engine color codes
        /// </summary>
        /// <param name="str">String containing color codes</param>
        /// <returns></returns>
        public static String StripColors(this string str)
        {
            if (str == null)
                return "";
            str = Regex.Replace(str, @"(\^+((?![a-z]|[A-Z]).){0,1})+", "");
            string str2 = Regex.Match(str, @"(^\/+.*$)|(^.*\/+$)")
                .Value
                .Replace("/", " /");
            return str2.Length > 0 ? str2 : str;
        }

        /// <summary>
        /// Get the IW Engine color code corresponding to an admin level
        /// </summary>
        /// <param name="level">Specified player level</param>
        /// <returns></returns>
        public static String ConvertLevelToColor(Player.Permission level)
        {
            switch (level)
            {
                case Player.Permission.Banned:
                    return "^1" + Player.Permission.Banned;
                case Player.Permission.Flagged:
                    return "^9" + Player.Permission.Flagged;
                case Player.Permission.Owner:
                    return "^5" + Player.Permission.Owner;
                case Player.Permission.User:
                    return "^2" + Player.Permission.User;
                case Player.Permission.Trusted:
                    return "^3" + Player.Permission.Trusted;
                default:
                    return "^6" + level;
            }
        }

        public static String ProcessMessageToken(IList<Helpers.MessageToken> tokens, String str)
        {
            MatchCollection RegexMatches = Regex.Matches(str, @"\{\{[A-Z]+\}\}", RegexOptions.IgnoreCase);
            foreach (Match M in RegexMatches)
            {
                String Match = M.Value;
                String Identifier = M.Value.Substring(2, M.Length - 4);

                var found = tokens.FirstOrDefault(t => t.Name.ToLower() == Identifier.ToLower());

                if (found != null)
                    str = str.Replace(Match, found.ToString());
            }

            return str;
        }

        public static bool IsBroadcastCommand(this string str)
        {
            return str[0] == '@';
        }

        /// <summary>
        /// Get the full gametype name
        /// </summary>
        /// <param name="input">Shorthand gametype reported from server</param>
        /// <returns></returns>
        public static String GetLocalizedGametype(String input)
        {
            switch (input)
            {
                case "dm":
                    return "Deathmatch";
                case "war":
                    return "Team Deathmatch";
                case "koth":
                    return "Headquarters";
                case "ctf":
                    return "Capture The Flag";
                case "dd":
                    return "Demolition";
                case "dom":
                    return "Domination";
                case "sab":
                    return "Sabotage";
                case "sd":
                    return "Search & Destroy";
                case "vip":
                    return "Very Important Person";
                case "gtnw":
                    return "Global Thermonuclear War";
                case "oitc":
                    return "One In The Chamber";
                case "arena":
                    return "Arena";
                case "dzone":
                    return "Drop Zone";
                case "gg":
                    return "Gun Game";
                case "snipe":
                    return "Sniping";
                case "ss":
                    return "Sharp Shooter";
                case "m40a3":
                    return "M40A3";
                case "fo":
                    return "Face Off";
                case "dmc":
                    return "Deathmatch Classic";
                case "killcon":
                    return "Kill Confirmed";
                case "oneflag":
                    return "One Flag CTF";
                default:
                    return input;
            }
        }

        public static long ConvertLong(this string str)
        {
            try
            {
                return Int64.Parse(str, System.Globalization.NumberStyles.HexNumber);
            }


            catch (FormatException)
            {
                return -1;
            }
        }

        public static int ConvertToIP(this string str)
        {
            try
            {
                return BitConverter.ToInt32(System.Net.IPAddress.Parse(str).GetAddressBytes(), 0);
            }

            catch (FormatException)
            {
                return 0;
            }
        }

        public static string ConvertIPtoString(this int ip)
        {
            return new System.Net.IPAddress(BitConverter.GetBytes(ip)).ToString();
        }

        public static String GetTimePassed(DateTime start)
        {
            return GetTimePassed(start, true);
        }

        public static String GetTimePassed(DateTime start, bool includeAgo)
        {
            TimeSpan Elapsed = DateTime.UtcNow - start;
            string ago = includeAgo ? " ago" : "";

            if (Elapsed.TotalSeconds < 30 && includeAgo)
                return "just now";
            if (Elapsed.TotalMinutes < 120)
            {
                if (Elapsed.TotalMinutes < 1.5)
                    return $"1 minute{ago}";
                return Math.Round(Elapsed.TotalMinutes, 0) + $" minutes{ago}";
            }
            if (Elapsed.TotalHours <= 24)
            {
                if (Elapsed.TotalHours < 1.5)
                    return $"1 hour{ago}";
                return Math.Round(Elapsed.TotalHours, 0) + $" hours{ago}";
            }
            if (Elapsed.TotalDays <= 365)
            {
                if (Elapsed.TotalDays < 1.5)
                    return $"1 day{ago}";
                return Math.Round(Elapsed.TotalDays, 0) + $" days{ago}";
            }
            else
                return $"a very long time{ago}";
        }

        public static Game GetGame(string gameName)
        {
            if (gameName.Contains("IW4"))
                return Game.IW4;
            if (gameName.Contains("CoD4"))
                return Game.IW3;
            if (gameName.Contains("WaW"))
                return Game.T4;
            if (gameName.Contains("COD_T5_S"))
                return Game.T5;
            if (gameName.Contains("T5M"))
                return Game.T5M;
            if (gameName.Contains("IW5"))
                return Game.IW5;
            if (gameName.Contains("COD_T6_S"))
                return Game.T6M;

            return Game.UKN;
        }

        public static TimeSpan ParseTimespan(this string input)
        {
            var expressionMatch = Regex.Match(input, @"[0-9]+.\b");

            if (!expressionMatch.Success) // fallback to default tempban length of 1 hour
                return new TimeSpan(1, 0, 0);

            char lengthDenote = expressionMatch.Value[expressionMatch.Value.Length - 1];
            int length = Int32.Parse(expressionMatch.Value.Substring(0, expressionMatch.Value.Length - 1));

            switch (lengthDenote)
            {
                case 'm':
                    return new TimeSpan(0, length, 0);
                case 'h':
                    return new TimeSpan(length, 0, 0);
                case 'd':
                    return new TimeSpan(length, 0, 0, 0);
                case 'w':
                    return new TimeSpan(length * 7, 0, 0, 0);
                case 'y':
                    return new TimeSpan(length * 365, 0, 0, 0);
                default:
                    return new TimeSpan(1, 0, 0);
            }
        }

        public static string TimeSpanText(this TimeSpan span)
        {
            if (span.TotalMinutes < 60)
                return $"{span.Minutes} minute(s)";
            else if (span.Hours >= 1 && span.TotalHours < 24)
                return $"{span.Hours} hour(s)";
            else if (span.TotalDays >= 1 && span.TotalDays < 7)
                return $"{span.Days} day(s)";
            else if (span.TotalDays >= 7 && span.TotalDays < 365)
                return $"{Math.Ceiling(span.Days / 7.0)} week(s)";
            else if (span.TotalDays >= 365 && span.TotalDays < 36500)
                return $"{Math.Ceiling(span.Days / 365.0)} year(s)";
            else if (span.TotalDays >= 36500)
                return "Forever";

            return "1 hour";
        }

        public static Player AsPlayer(this Database.Models.EFClient client)
        {
            return client == null ? null : new Player()
            {
                Active = client.Active,
                AliasLink = client.AliasLink,
                AliasLinkId = client.AliasLinkId,
                ClientId = client.ClientId,
                ClientNumber = -1,
                FirstConnection = client.FirstConnection,
                Connections = client.Connections,
                NetworkId = client.NetworkId,
                TotalConnectionTime = client.TotalConnectionTime,
                Masked = client.Masked,
                Name = client.CurrentAlias.Name,
                IPAddress = client.CurrentAlias.IPAddress,
                Level = client.Level,
                LastConnection = DateTime.UtcNow,
                CurrentAlias = client.CurrentAlias,
                CurrentAliasId = client.CurrentAlias.AliasId
            };
        }

        public static bool IsPrivileged(this Player p) => p.Level > Player.Permission.User;

        public static bool PromptBool(string question)
        {
            Console.Write($"{question}? [y/n]: ");
            return (Console.ReadLine().ToLower().FirstOrDefault() as char?) == 'y';
        }

        public static string PromptString(string question)
        {
            Console.Write($"{question}: ");

            string response;
            do
            {
                response = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(response));

            return response;
        }

        public static async Task<DVAR<T>> GetDvarAsync<T>(this Server server, string dvarName)
        {
            string[] LineSplit = await server.RemoteConnection.SendQueryAsync(QueryType.DVAR, dvarName);

            if (LineSplit.Length != 3)
            {
                var e = new Exceptions.DvarException($"DVAR \"{dvarName}\" does not exist");
                e.Data["dvar_name"] = dvarName;
                throw e;
            }

            string[] ValueSplit = LineSplit[1].Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries);

            if (ValueSplit.Length != 5)
            {
                var e = new Exceptions.DvarException($"DVAR \"{dvarName}\" does not exist");
                e.Data["dvar_name"] = dvarName;
                throw e;
            }

            string DvarName = Regex.Replace(ValueSplit[0], @"\^[0-9]", "");
            string DvarCurrentValue = Regex.Replace(ValueSplit[2], @"\^[0-9]", "");
            string DvarDefaultValue = Regex.Replace(ValueSplit[4], @"\^[0-9]", "");

            return new DVAR<T>(DvarName) { Value = (T)Convert.ChangeType(DvarCurrentValue, typeof(T)) };
        }

        public static async Task SetDvarAsync(this Server server, string dvarName, object dvarValue)
        {
            await server.RemoteConnection.SendQueryAsync(QueryType.DVAR, $"set {dvarName} {dvarValue}");
        }

        public static async Task<string[]> ExecuteCommandAsync(this Server server, string commandName)
        {
            return (await server.RemoteConnection.SendQueryAsync(QueryType.COMMAND, commandName)).Skip(1).ToArray();
        }

        public static async Task<List<Player>> GetStatusAsync(this Server server)
        {
#if DEBUG && DEBUG_PLAYERS
            string[] response = await Task.Run(() => System.IO.File.ReadAllLines("players.txt"));
#else
            string[] response = await server.RemoteConnection.SendQueryAsync(QueryType.DVAR, "status");
#endif
            return Utilities.PlayersFromStatus(response);
        }

        public static bool IsRunningOnMono() => Type.GetType("Mono.Runtime") != null;
    }
}