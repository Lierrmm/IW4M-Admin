using SharedLibraryCore;
using SharedLibraryCore.Database.Models;
using System.Threading.Tasks;
using t6ScriptCommands;

namespace IW4MAdmin.Plugins.Login.Commands
{
    public class updateList : Command
    {
        public updateList() : base("updatelist", "Update Verified Dvar", "ul", EFClient.Permission.Moderator, false, null)
        { }

        public override async Task ExecuteAsync(GameEvent E)
        {
            Plugin plugin = new Plugin();
            Plugin.verified = await plugin.getVerifiedUsers();
            await E.Owner.SetDvarAsync("sv_verifiedClients", plugin.buildUglyStr(Plugin.verified));
            E.Origin.Tell("Updated Dynamo Clients");
        }
    }
}
