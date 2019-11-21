namespace Player.Items
{
    public interface IEqItem
    {
        float MainCooldown { get; }
        float AdditionalCooldown { get; }
        float MainForceValue { get; }
        float AdditionalForceValue { get; }
        float ShotSpeed { get; }

        void MainAction(PlayerActionsController playerActions);
        void AdditionalAction(PlayerActionsController playerActions);
        void PasiveAction(float dt);
    }
}