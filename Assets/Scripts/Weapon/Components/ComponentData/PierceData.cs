namespace Powerfish.WeaponSystem.Components
{
    public class PierceData : ComponentData<AttackPierce>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Pierce);
        }
    }
}