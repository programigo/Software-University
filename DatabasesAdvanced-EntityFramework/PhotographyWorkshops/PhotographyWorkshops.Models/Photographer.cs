using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Photographer
{
    public Photographer()
    {
        this.Lenses = new HashSet<Lens>();
        this.Workshops = new HashSet<Workshop>();
        this.Accessories = new HashSet<Accessory>();
    }
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required, MinLength(2), MaxLength(50)]
    public string LastName { get; set; }

    [RegularExpression(@"^(\+([0-9]){1,3})\/([0-9]{8,10})")]
    public string Phone { get; set; }

    [Required]
    public virtual Camera PrimaryCamera{ get; set; }

    [Required]
    public virtual Camera SecondaryCamera { get; set; }

    public virtual ICollection<Lens> Lenses { get; set; }

    public virtual ICollection<Accessory> Accessories { get; set; }

    public virtual ICollection<Workshop> Workshops { get; set; }
}
