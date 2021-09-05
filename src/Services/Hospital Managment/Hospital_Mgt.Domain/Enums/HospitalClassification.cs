using System.ComponentModel.DataAnnotations;

namespace HospitalMgt.Domain.Enums
{
    public enum HospitalClassification
    {
        [Display(Name = "Childrens hospital")]
        Childrens_Hospital,
        [Display(Name = "Psychatry hospital")]
        Psychatry_Hospital,
        [Display(Name = "Rehabilation hospital")]
        Rehabilitation_Hospital,
        [Display(Name = "Clinics")]
        Clinics
    }
}
