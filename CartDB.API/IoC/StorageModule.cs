using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Azure.Storage.Blobs;
using CartDB.API.Configuration;

namespace CartDB.API.IoC
{
    public class StorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Settings
            var storageConfig = ConfigurationHelper.StorageConfig;
            var connectionString = storageConfig.StorageConnectionString;
            var containerName = storageConfig.ImageContainer;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Storage Connection String cannot be empty");
            }

            if (string.IsNullOrEmpty(containerName))
            {
                throw new InvalidOperationException("Storage Container Name cannot be empty");
            }

            // Registrations
            builder.Register(context =>
            {
                var serviceClient = new BlobServiceClient(connectionString);
                var containerClient = serviceClient.GetBlobContainerClient(containerName);
                containerClient.CreateIfNotExistsAsync()
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                return containerClient;
            })
                .As<BlobContainerClient>()
                .InstancePerLifetimeScope();
        }
    }
}
