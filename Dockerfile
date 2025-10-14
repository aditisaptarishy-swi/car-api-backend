# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy everything and publish the release
COPY . ./
RUN dotnet publish -c Release -o out

# Use the ASP.NET Core runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose the port the app runs on
EXPOSE 8080

# Run the app
ENTRYPOINT ["dotnet", "MyApiApp.dll"]
