using System;
using System.Collections.Generic;

public class Cata
{
    public int Id { get; set; }
    public required string  Nombre { get; set; }
    public DateTime Fecha { get; set; }
    public required List<Wine>  Vinos { get; set; }
    public required List<string> Invitados { get; set; }
}
