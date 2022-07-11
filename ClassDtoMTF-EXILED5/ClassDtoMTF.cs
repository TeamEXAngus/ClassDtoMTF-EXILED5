using System;
using Exiled.API.Features;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace ClassDtoMTF
{
    public class ClassDtoMTF : Plugin<Config>
    {
        internal static ClassDtoMTF Instance;

        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 1);
        public override Version Version { get; } = new Version(1, 0, 0);

        public override string Name { get; } = "Class-D to MTF";
        public override string Author { get; } = "TeamEXAngus#5525";

        private Handlers.ChangingRole ChangingRole;

        public ClassDtoMTF()
        {
            Instance = this;
        }

        public override void OnEnabled()
        {
            ChangingRole = new Handlers.ChangingRole();

            PlayerHandler.ChangingRole += ChangingRole.OnChangingRole;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandler.ChangingRole -= ChangingRole.OnChangingRole;

            ChangingRole = null;

            base.OnDisabled();
        }
    }
}