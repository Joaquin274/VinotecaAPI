public class WineRepository
{
    private readonly List<Wine> _winesInventory;

    public WineRepository()
    {
        // Inicialización de la lista de vinos con algunos ejemplos
        _winesInventory = new List<Wine>
        {
            new Wine { Id = 1, Name = "Cabernet Sauvignon", Variety = "Tinto", Year = 2018, Region = "Mendoza", Stock = 50 },
            new Wine { Id = 2, Name = "Chardonnay", Variety = "Blanco", Year = 2020, Region = "La Rioja", Stock = 30 },
            new Wine { Id = 3, Name = "Malbec", Variety = "Tinto", Year = 2019, Region = "Mendoza", Stock = 45 }
        };
    }

    // Obtener todos los vinos en el inventario
    public List<Wine> GetWines()
    {
        return _winesInventory;
    }

    // Agregar un nuevo vino al inventario
    public void AddWine(Wine newWine)
    {
        // Asignar un ID nuevo al vino
        newWine.Id = _winesInventory.Count > 0 ? _winesInventory.Max(w => w.Id) + 1 : 1;
        _winesInventory.Add(newWine);
    }

    // Obtener la lista completa del inventario
    public List<Wine> WinesInventory()
    {
        return _winesInventory;
    }
}
