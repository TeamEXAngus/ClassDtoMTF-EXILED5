using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;

namespace ClassDtoMTF
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("The role that cuffed Class-D become when they escape")]
        public RoleType CuffedClassDNewRole { get; set; } = RoleType.FacilityGuard;

        [Description("The items given to cuffed Class-D when they escape")]
        public List<ItemType> CuffedClassDItems { get; set; } = new()
        {
            ItemType.KeycardGuard,
            ItemType.GunFSP9,
            ItemType.GunCOM18,
            ItemType.GrenadeFlash,
            ItemType.Radio,
            ItemType.Medkit,
            ItemType.ArmorCombat
        };

        [Description("The ammo given to cuffed Class-D when they escape")]
        public Dictionary<AmmoType, ushort> CuffedClassDAmmo { get; set; } = new()
        {
            { AmmoType.Nato9, 60 },
            { AmmoType.Nato556, 10 }
        };
    }
}