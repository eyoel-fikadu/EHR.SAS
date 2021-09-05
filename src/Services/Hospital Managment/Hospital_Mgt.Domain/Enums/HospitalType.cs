using System.ComponentModel.DataAnnotations;

namespace HospitalMgt.Domain.Enums
{
    public enum HospitalType
    {
        [Display(Name = "Publicly owned")]
        Publicly_Owned,
        [Display(Name = "Non profit hospital")]
        Non_Profit,
        [Display(Name = "For profit hospital")]
        For_Profit
    }
}
