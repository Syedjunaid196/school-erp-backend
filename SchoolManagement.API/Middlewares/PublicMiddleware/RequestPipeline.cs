using SchoolManagement.Persistence.Extensions;
using System.Runtime.CompilerServices;

namespace SchoolManagement.API.Middlewares.PublicMiddleware
{
    public static class RequestPipeline
    {
        public static async Task<WebApplication> UsePublicMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("AllowFrontend");

            app.UseAuthorization();

            app.MapControllers();

            await app.Services.SeedDataBaseAsync();

 
            return app;
        }
    }
}
