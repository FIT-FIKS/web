# FIKS Web

## Dependencies

```
dotnet 6
```
(tested using `dotnet 6.0.102`)

## Debug and run

For best experience, use JetBrains Rider. Choose profile (top-left corner, `fiks-web: development` or `fiks-web: production`) and click `Run` or `Debug`.

In terminal:

Run:
```
dotnet run # Development
dotnet run --launch-profile=development # Another way to run development mode

dotnet run --launch-profile=production # Production
```

Compile:
```
dotnet build --debug # Development

dotnet build # Production
```

Optionally, one can add `--sc` flag to `dotnet build` to build a self-contained binary, so that .NET runtime doesn't have to be installed on target machine. `-a <arch>` and `--os <os>` can also be specified to target architecture and operating system.
