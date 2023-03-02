## SportReader.API
SportReader.API .Net 6.x support !

## IoC
ASP.NET Core Dependency <br/>

## Principles
SOLID <br/>
Domain Driven Design<br/>
Test Driven Design<br/>

## Object Mappers
AutoMapper

## Cache
Redis

## Object Validation
FluentValidation

## Log
Serilog support
Elasticsearch
Kibana

## Documentation
Swagger

## CQRS
Mediatr

## Benefits
 - Conventional Dependency Registering
 - Async await first 
 - GlobalQuery Filtering
 - Domain Driven Design Concepts
 - Object to object mapping with abstraction
 - .Net 6.x support
 - Simple Usage
 - Modularity
 - Event Sourcing
 - Second Level Cache
 
   

***Basic Usage***

     WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
					
					
***Conventional Registration***	 	

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IFixtureRepository, FixtureRepository>();
        }

        public static void ConfigureMediatr(this IServiceCollection services)
        {
            services.AddScoped<IApplicationCommandQuery, ApplicationCommandQuery>();
        }

  
***AutoMapper Activation***

    public class Mapping : Profile
    {
        public Mapping()
        {

        }
    }
	 
***Swagger Activation***

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SportRadar", new OpenApiInfo
                {
                    Title = "SportRadar API",
                    Version = "SportRadar",
                    Description = "SportRadar Web API Documentation",
                });
            });
        }

***Serilog Activation***

		
		 Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .Enrich.WithProperty("Application", "app")
               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
               .MinimumLevel.Override("System", LogEventLevel.Warning)
               //.WriteTo.File(new JsonFormatter(), "log.json")
               //.ReadFrom.Configuration(configuration)
               .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("localhost:9200"))
               {
                   AutoRegisterTemplate = true,
                   AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                   FailureCallback = e => Console.WriteLine("fail message: " + e.MessageTemplate),
                   EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                      EmitEventFailureHandling.WriteToFailureSink |
                                      EmitEventFailureHandling.RaiseCallback,
                   FailureSink = new FileSink("log" + ".json", new JsonFormatter(), null)
               })
               .MinimumLevel.Verbose()
               .CreateLogger();
           Log.Information("WebApi Starting...");
		
		

***ErrorHandlingMiddleware Interceptor Activation***

     public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                Log.Write(LogEventLevel.Information, "Service path is:" + context.Request.Path.Value,
                    context.Request.Body);
                await next(context);
            }
            catch (HttpRequestException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (AuthenticationException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (BusinessException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, ex.Source, ex.TargetSite, ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, object exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var message = string.Empty;
            var RC = string.Empty;

            if (exception.GetType() == typeof(HttpRequestException))
            {
                code = HttpStatusCode.NotFound;
                RC = ResponseMessage.NotFound;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(AuthenticationException))
            {
                code = HttpStatusCode.Unauthorized;
                RC = ResponseMessage.Unauthorized;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(BusinessException))
            {
                var businesException = (BusinessException) exception;
                message = BusinessException.GetDescription(businesException.RC, businesException.param1);
                code = HttpStatusCode.InternalServerError;
                RC = businesException.RC;
            }
            else if (exception.GetType() == typeof(Exception))
            {
                code = HttpStatusCode.BadRequest;
                RC = ResponseMessage.BadRequest;
                message = BusinessException.GetDescription(RC);
            }

            var response = new Error
            {
                Message = message,
                RC = RC
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
	
	
***Query definitions***


	
***Handlers definitions***	


***Redis Repository definitions***
     

