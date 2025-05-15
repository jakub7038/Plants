namespace Plants.Data.Helpers
{
    public static class DatabaseCleaner
    {
        public static void Clean(AppDbContext context)
        {
            Console.WriteLine("Usuwanie danych...");

            context.CareLogs.RemoveRange(context.CareLogs);
            context.SaveChanges();
            Console.WriteLine("Usunięto wszystkie CareLogs.");

            context.Plants.RemoveRange(context.Plants);
            context.SaveChanges();
            Console.WriteLine("Usunięto wszystkie Plants.");

            context.Species.RemoveRange(context.Species);
            context.SaveChanges();
            Console.WriteLine("Usunięto wszystkie Species.");

            Console.WriteLine("Czyszczenie bazy zakończone!");
        }
    }
}
