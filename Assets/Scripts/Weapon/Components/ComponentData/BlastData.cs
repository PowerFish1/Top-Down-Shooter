namespace Powerfish.WeaponSystem.Components
{
    public class BlastData : ComponentData<AttackBlast>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Blast);
        }
    }
}