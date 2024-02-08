# GymUnityApi

## Getting started

0. Create a docker network for the api and the database

```bash
docker network create -d bridged gymunity
```


1. Create a docker postgres container for dev

```bash
docker run --name gymunityapi-postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 --network gymunity --network-alias gymunity-postgres -d postgres
```

2. Launch database migrations
    
    ```bash
    dotnet tool install --global dotnet-ef
    dotnet ef database update
    ```