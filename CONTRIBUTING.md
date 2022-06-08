# FIKS Web

## Add new database model

- Create new class in `Models` folder. Make sure to include the `{ get; set; }`.
- For migrations, you will need ef migrations tool. Run `dotnet tool install --global dotnet-ef`
- Create DB migration so that new database table is generated everywhere. Use `dotnet ef migrations add <Name>`,
it's best to choose name relating to added model as migration name.
- (if anything goes wrong, migrations can be removed and re-added via `dotnet ef migrations remove`)
- To run migration, use `dotnet ef database update`.

## Adding new pages

- Create new razor page at `Pages` directory.