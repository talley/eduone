var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.EduOne_Fr_RestServices>("eduone-fr-restservices");

builder.Build().Run();
