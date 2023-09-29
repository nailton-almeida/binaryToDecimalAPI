
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/binario/{string}", (string binario) =>
{
    int decimalCalculated = 0;
    int characterBackwardsRead = 1;
 
    if(!Regex.IsMatch(binario, "^[01]*$"))
    {
        return Results.BadRequest("Somente são aceitos valores definidos por 0 e 1");
    }
     

    for (int i = 0; characterBackwardsRead <= binario.Length; i++)
    {

        
        int getlastBinary = ((int)Char.GetNumericValue(binario[^characterBackwardsRead]));
        decimalCalculated += (int)(getlastBinary * (Math.Pow(2, i)));
        characterBackwardsRead++;

    }
     return Results.Ok($"O Binario {binario} em decimal é {decimalCalculated}");
});

app.Run();

 

 
 


