using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace rrhh_api.Models;

public partial class RefreshToken
{
    [Column(TypeName = "nvarchar(1024)")]
    public string TokenId { get; set; } = null!;

    [Column(TypeName = "varchar(100)")]
    public string? CodUsuario { get; set; }

    [Column(TypeName = "nvarchar(1024)")]
    public string? RefreshToken1 { get; set; }

    public virtual Usuario? CodUsuarioNavigation { get; set; }
}
