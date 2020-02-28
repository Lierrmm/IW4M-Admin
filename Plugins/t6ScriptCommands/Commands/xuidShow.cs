using SharedLibraryCore;
using SharedLibraryCore.Database.Models;
using System.Threading.Tasks;
using t6ScriptCommands;

namespace IW4MAdmin.Plugins.Login.Commands
{
    public class xuidShow : Command
    {
        public xuidShow() : base("xuid", "Show My XUID", "xuid", EFClient.Permission.User, false, null)
        { }

        public override async Task ExecuteAsync(GameEvent E)
        {
            E.Origin.Tell("Here is your XUID. Give it to an Admin for VIP Purchase.");
            E.Origin.Tell("XUID: " + toXUID(E.Origin.NetworkId).ToUpper());
        }

        public string toXUID(long id)
        {
            return id.ToString("X");
        }
    }
}
