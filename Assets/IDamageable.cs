
namespace TowerDefence
{
    /// <summary>
    /// Interface for retrieving, resetting health information and taking damage.
    /// </summary>
    public interface IDamageable
    {
		/// <summary>
		/// Returns the object's current health.
		/// </summary>
		int CurrentHealth { get; }

		/// <summary>
		/// Returns the object's maximum health amount.
		/// </summary>
		int MaxHealth { get; }

		/// <summary>
		/// Decreases the CurrentHealth by the amount. 
		/// </summary>
		/// <param name="amount">The amount CurrentHealth is decreased by.</param>
		void DecreaseHealth(int amount);

		/// <summary>
		/// Resets component's health values to their original state.
		/// </summary>
		void ResetHealth();

		/// <summary>
		/// Called when ever the object takes damage. Sends the damage amount to DecreaseHealth method.
		/// </summary>
		/// /// <param name="amount">The amount of damage dealt to the object.</param>
		void TakeDamage(int amount);
		
	}
}
