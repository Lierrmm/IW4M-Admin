using SharedLibraryCore;
using SharedLibraryCore.Database.Models;
using System.Threading.Tasks;
using t6ScriptCommands;

namespace IW4MAdmin.Plugins.Login.Commands
{
    public class vipMessage : Command
    {
        public vipMessage() : base("vip", "Update Verified Dvar", "vip", EFClient.Permission.Moderator, false, null)
        { }

        public override async Task ExecuteAsync(GameEvent E)
        {
            E.Owner.Broadcast("^3$3.50^7 for VIP - All VIP's get access to VIP Menu");
            E.Owner.Broadcast("Purchase Via Discord: ^5www.gsc.rocks");
        }
    }
}
