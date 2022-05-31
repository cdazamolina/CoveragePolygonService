using CoveragePolygonService.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoveragePolygonService.Api
{
    public static class Configurations
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<CoveragePolygonContext>();
            db.Database.Migrate();
            return app;
        }
    }
}
