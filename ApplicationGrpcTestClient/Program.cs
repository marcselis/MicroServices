// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using static ApplicationManagement.Applications;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("https://localhost:6001");
var client = new ApplicationsClient(channel);
var application = await client.GetApplicationAsync(new ApplicationManagement.ApplicationRequest { ApplicationId = 1 });
Console.WriteLine(application.Name);
