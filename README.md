# checkpoint.crm.net
Checkpoint CRM .NET Client library

Simple usage example:
```csharp
var cli = new CheckpointClient("http://checkpointcrm.ru", "<TOKEN_OBTAINED_FROM_ADMINISTRATOR>");
var pointOfSales = cli.FindPointOfSales(new PointOfSaleFilter());
```
