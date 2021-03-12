
namespace TowerDefence
{
    /// <summary>
    /// Generic Object pool base class which will be used to create sub object pools.
    /// </summary>
    public interface IDamageable
    {
		/// <summary>
		/// Returns character's current health.
		/// </summary>
		int CurrentHealth { get; }

		/// <summary>
		/// Health's maximum amount.
		/// </summary>
		int MaxHealth { get; }

		/// <summary>
		/// Indicates weather the character is immortal and does not take damage. Is the character
		/// is immortal, CurrentHealth can't be reduced even though the character
		/// is damaged.
		/// </summary>
		bool IsImmortal { get; set; }

		/// <summary>
		/// Increases the CurrentHealth by the amount. CurrentHealth can never exceed MaxHealth.
		/// </summary>
		/// <param name="amount">The amount CurrentHealth is increased by.</param>
		void IncreaseHealth(int amount);

		/// <summary>
		/// Decreases the CurrentHealth by the amount. CurrentHealth can never go beneath
		/// MinHealth.
		/// </summary>
		/// <param name="amount">The amount CurrentHealth is decreased by.</param>
		void DecreaseHealth(int amount);

		/// <summary>
		/// Resets component's values to their original state.
		/// </summary>
		void ResetHealth();

		/// <summary>
		/// Called when ever the object takes damage. Sends the amount to DecreaseHealth method.
		/// </summary>
		void TakeDamage(int amount);
		
	}
}
