using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Framework.Data.MongoDB
{
    public static class MongoDBExtensions
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection(nameof(MongoDBSettings)));

            var settings = services.BuildServiceProvider().GetRequiredService<IOptions<MongoDBSettings>>().Value;

            // MongoClient (Singleton)
            var mongoUrl = new MongoUrl(settings.Uri);
            var mongoConnection = new MongoDBConnectionWraper
            {
                MongoURL = mongoUrl,
                MongoClient = new MongoClient(mongoUrl)
            };

            services.AddSingleton(mongoConnection);

            services.AddHealthChecks()
                .AddMongoDb(settings.Uri, "mongodb", failureStatus: null, tags: new string[] { "db", "mongodb" });

            return services;
        }
    }
}
