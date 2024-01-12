# GymUnityApi

## Getting started

1. Create a docker postgres container for dev

```bash
docker run --name gymunityapi-postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres
```

2. Launch database migrations
    
    ```bash
    dotnet tool install --global dotnet-ef
    dotnet ef database update
    ```