namespace KooliProjekt.Application.Infrastructure.Files
{
    public static class FileStore
    {
        public const string Photos = "photos";
        public const string Invoices = "invoices";
        public const string Cars = "cars";
        public static string ForCar(int id)
        {
            if (id <= 0) throw new System.ArgumentOutOfRangeException(nameof(id));
            return Cars + "/" + id.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
