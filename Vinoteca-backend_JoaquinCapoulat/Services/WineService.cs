public class WineService
{
    private readonly WineRepository _wineRepository;

    public WineService(WineRepository wineRepository)
    {
        _wineRepository = wineRepository;
    }

    // Obtener todos los vinos
    public List<Wine> GetAllWines()
    {
        return _wineRepository.GetWines();
    }

    // Agregar un nuevo vino al inventario
    public void AddWine(Wine newWine)
    {
        if (newWine == null)
        {
            throw new ArgumentNullException(nameof(newWine));
        }

        // Validar que el vino tenga datos correctos
        if (string.IsNullOrWhiteSpace(newWine.Name) ||
            string.IsNullOrWhiteSpace(newWine.Variety) ||
            newWine.Year <= 0 ||
            string.IsNullOrWhiteSpace(newWine.Region) ||
            newWine.Stock < 0)
        {
            throw new ArgumentException("Datos inválidos para el vino.");
        }

        _wineRepository.AddWine(newWine);
    }

    // Obtener un vino específico por su nombre
    public Wine? GetWineByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "El nombre del vino no puede ser nulo o vacío.");
        }

        var wines = _wineRepository.WinesInventory();
        return wines.FirstOrDefault(w => w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // Actualizar el stock de un vino
    public void UpdateStock(int wineId, int newStock)
    {
        var wine = _wineRepository.GetWines().FirstOrDefault(w => w.Id == wineId);
        if (wine == null)
        {
            throw new ArgumentException($"No se encontró ningún vino con el ID {wineId}.");
        }

        if (newStock < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo.");
        }

        wine.Stock = newStock;
    }
}
