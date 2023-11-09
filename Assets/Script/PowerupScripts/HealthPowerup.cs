
[System.Serializable]
public class HealthPowerup : Powerup
{
    public float healthToAdd;
   
    public override void Apply(PowerupManager target)
    {
        // Apply Health changes
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            // the second parameter is the pawn who caused the healing - in this case, they healed themselves
            targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
        // TODO: Remove Health
        Health targetHealth = target.GetComponent<Health>();
        if(targetHealth != null)
        {
            targetHealth.takeDamage(healthToAdd, target.GetComponent<Pawn>());
        }
    }

    
}
