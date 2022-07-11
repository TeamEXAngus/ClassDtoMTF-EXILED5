using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using MEC;
using Exiled.API.Extensions;
using System;

namespace ClassDtoMTF.Handlers
{
    internal class ChangingRole
    {
        private Config Configs => ClassDtoMTF.Instance.Config;

        internal void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Reason == SpawnReason.Escaped &&
                ev.NewRole == RoleType.NtfPrivate)
            {
                ev.Lite = true;
                ev.NewRole = Configs.CuffedClassDNewRole;

                Timing.CallDelayed(0.1f, () =>
                {
                    (ev.Player.Position, _) = RoleExtensions.GetRandomSpawnProperties(RoleType.NtfPrivate); // Returns Tuple with (spawpos, rotation)
                    ev.Player.ResetInventory(Configs.CuffedClassDItems);
                    foreach (var kvp in Configs.CuffedClassDAmmo)
                        ev.Player.SetAmmo(kvp.Key, kvp.Value);
                });
            }
        }
    }
}