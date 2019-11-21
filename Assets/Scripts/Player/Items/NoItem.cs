namespace Player.Items
{
    public class NoItem : IEqItem
    {
        public float MainCooldown { get; } = 1f;
        public float AdditionalCooldown { get; } = 1f;
        public float MainForceValue { get; } = 1f;
        public float AdditionalForceValue { get; } = 1f;
        public float ShotSpeed { get; } = 1f;
        
        public void MainAction(PlayerActionsController playerActions)
        {
            // do nothing
        }

        public void AdditionalAction(PlayerActionsController playerActions)
        {
            // do nothing
        }

        public void PasiveAction(float dt)
        {
            // do nothing
        }
    }
}