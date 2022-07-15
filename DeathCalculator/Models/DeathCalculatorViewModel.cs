using System.ComponentModel.DataAnnotations;


namespace DeathCalculator.Models
{
    public class DeathCalculatorViewModel
    {
        #region Properties

        [Required]
        [Display(Name = "Age of Death Person A")]
        public int AgeOfDeathA { get; set; }

        [Required]
        [Display(Name = "Year of Death Person A")]
        public int YearOfDeathA { get; set; }

        [Required]
        [Display(Name = "Age of Death Person B")]
        public int AgeOfDeathB { get; set; }

        [Required]
        [Display(Name = "Year of Death Person B")]
        public int YearOfDeathB { get; set; }

        #endregion
    }
}