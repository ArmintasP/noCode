To run migration:

```bash
cd ./NoCode.FlowerShop.Infrastructure
dotnet ef --startup-project ../NoCode.FlowerShop.Api/ migrations add MIGRATIONAME -o ./Persistence/Migrations
```

After that, check the auto-generated migration file. 
If constraints don't match expectations, write own configuration file.
If constraints are all right, then run:

```
dotnet ef --startup-project ../NoCode.FlowerShop.Api/ database update
```