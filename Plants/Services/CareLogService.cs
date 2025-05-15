using Plants.Data.Helpers;
using Plants.Models;

namespace Plants.Services
{
    public class CareLogService
    {
        public void AddCareLog(CareLog careLog)
        {
            using var context = DbContextHelper.Create();

            context.CareLogs.Add(careLog);
            context.SaveChanges();
        }
    }
}
