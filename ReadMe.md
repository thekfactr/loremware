# Loremware

Loremware is a really simple middleware that attempts to solve a really simple task of providing some dummy 
content for your pages!

## Usage

* Use nuget to first include the package to your project
* In your `Startup.cs` file, in the `Configure` method add the following

```csharp
if (env.IsDevelopment())
{
	app.UseLoremware();
}
```
