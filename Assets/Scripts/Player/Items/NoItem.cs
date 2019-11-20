namespace Player.Items
{
    public class NoItem : IEqItem
    {
        public float MainCooldown { get; } = 1f;
        public float AdditionalCooldown { get; } = 1f;
        public float MainForceValue { get; } = 1f;
        public float AdditionalForceValue { get; } = 1f;
        
        public void MainAction()
        {
            // do nothing
        }

        public void AdditionalAction()
        {
            // do nothing
        }

        public void PasiveAction()
        {
            // do nothing
        }
    }
}