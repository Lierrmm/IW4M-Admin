using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using SharedLibraryCore;
using SharedLibraryCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using SharedLibraryCore.Database.Models;

namespace t6ScriptCommands
{
    public class Plugin : IPlugin
    {
        public string Name => "T6 Script Commands";

        public float Version => 1.0f;

        public string Author => "Liam";

        public static string AWS_Access;
        public static string AWS_Secret;
        public static string AWS_Session;
        private static AmazonDynamoDBClient client;
        private static DynamoDBContext context;
        public static List<string> verified;

        [DynamoDBTable("plutoVerified")]
        class plutoVerified
        {
            [DynamoDBHashKey]
            public string xuid { get; set; }
            public string name { get; set; }
        }

        public static void GetAWSKeys()
        {
            var credentialProfileStoreChain = new CredentialProfileStoreChain();
            AWSCredentials credentials;
            credentialProfileStoreChain.TryGetAWSCredentials("default", out credentials);
            ImmutableCredentials creds = credentials.GetCredentials();
            AWS_Access = creds.AccessKey;
            AWS_Secret = creds.SecretKey;
            if (creds.UseToken) AWS_Session = creds.Token;
            client = new AmazonDynamoDBClient(AWS_Access, AWS_Secret, RegionEndpoint.EUWest1);
            context = new DynamoDBContext(client);
        }

        public async Task OnEventAsync(GameEvent E, Server S)
        {
            if (E.Type == GameEvent.EventType.Start)
            {
                GetAWSKeys();
                verified = await getVerifiedUsers();
                await S.SetDvarAsync("sv_verifiedClients", buildUglyStr(verified));
            }
        }

        public Task OnLoadAsync(IManager manager) => Task.CompletedTask;

        public Task OnTickAsync(Server S) => Task.CompletedTask;

        public Task OnUnloadAsync() => Task.CompletedTask;

        public string buildUglyStr(List<string> str)
        {
            string _finalstr = "";
            foreach(string _str in str)
                _finalstr += $"{_str.ToLower()};";
            return _finalstr;
        }

        public async Task<List<string>> getVerifiedUsers()
        {
            try
            {
                var scanSearch = context.ScanAsync<plutoVerified>(null);
                var _items = await scanSearch.GetRemainingAsync();
                List<string> xuids = new List<string>();
                foreach(var item in _items) xuids.Add(item.xuid);
                return xuids != null && xuids.Count > 0 ? xuids : null;
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
