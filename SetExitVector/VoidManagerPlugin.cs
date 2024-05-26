using VoidManager.MPModChecks;

namespace SetExitVector
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Automatically sets the exit vector when the void drive is charged, and a destination sector when entering a void jump";
    }
}
