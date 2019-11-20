namespace Player.Items
{
    public interface IEqItem
    {
        float MainCooldown { get; }
        float AdditionalCooldown { get; }
        float MainForceValue { get; }
        float AdditionalForceValue { get; }

        void MainAction();
        void AdditionalAction();
        void PasiveAction();
    }
}