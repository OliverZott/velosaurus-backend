# Setup project
- Create Project and Solution `ASP.NET Core Web API`
- **CORS** configuration [Link](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0)
- **Serilog** and **Seq**
  - **ps script** for checking and starting mongodb and seq service
- MongoDB driver and configuration



# Next steps

### Frontend
- Bootstrap for Tour list example page
- Resolve enum in forntend
	- How use ENUM in controller ?!
- Post request formular in frontend

### backend
- Exception handling 
	- ID
	- no entry found
- DEPLOY
	- Seq online - for hosted env
	- Mongo online - Atlass instead local instance
	- Deployment with Atlas

- DTOs in frontende / backend ?! (how map api reponse on jsx object)



# Questions
- How use ENUM in controller ?!
- DTOs in frontende / backend ?! (how map api reponse on jsx object)



# Remarks
## Serilog
- https://www.youtube.com/watch?v=MYKTwvowMUI
- https://www.youtube.com/watch?v=hJ0QHRV3RPQ
	- https://github.com/rstropek/htl-leo-pro-5/tree/master/lectures/0500-api-error-handling/WebApiErrorHandling.Server
- https://www.youtube.com/watch?v=_iryZxv8Rxw


## Seq
- **Install** seq and use **Sink** in `appsettings.json`
- Using RequestID in search to find all request related stuff: `RequestId = "0HMHQ499O1RPJ:0000001B"`


##  MongoDB
- NO Entityframework Core (best for relational databases!)
- MongoDb.Driver nuget
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio
- https://www.youtube.com/watch?v=exXavNOqaVo

- Add configuration and configuration model
	- `appsettings.json`
	- settings class in `Models` directory, to store appsettings properties
	- `Program.cs` 


## Json Serializer
- https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-6.0#configure-systemtextjson-based-formatters

## Error / Exception handling
- https://jasonwatmore.com/post/2022/01/17/net-6-global-error-handler-tutorial-with-example
- https://weblogs.asp.net/fredriknormen/asp-net-web-api-exception-handling
- https://stackoverflow.com/questions/10732644/best-practice-to-return-errors-in-asp-net-web-api
- https://docs.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling
- https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-6.0


# Start App
- Serilog: http://localhost:5341/#/events
- App: https://localhost:7269/swagger/index.html