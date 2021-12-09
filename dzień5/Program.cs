var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseRouting();

}
app.UseHttpsRedirection();

var villages = new List<Village>();
villages.Add(new Village(name: "Biały Sad", people: 20));
villages.Add(new Village(name: "Podgaje", people: 25));
villages.Add(new Village(name: "Zalipie", people: 40));
villages.Add(new Village(name: "Poróg", people: 10));
villages.Add(new Village(name: "Jawornik", people: 30));

app.MapGet("/", async (context) =>
{
  var html = $@"
<html>
    <head><meta charset=""UTF-8""></head>
    <body>
        <center>
        Witaj Panie<br>
        O to twoje wsie.<br><br>
            {villages
            .Select((v, i) => (name: v.name, people: v.people, index: i))
            .Aggregate("", (acc, v) => @$"
            {acc}
            <a href=""/villages/{v.index}"">{v.name}</a><br>
            ")}
            <br>
            <div id=""inp""><button id=""add"">dodaj wieś</button></div>
        </center>
    </body>
    <script>
      let add = document.getElementById('add')
      let inp = document.getElementById('inp')
      add.onclick=()=>{{
        inp.innerHTML = `
        <br>Nazwa wsi <input type=""text"" id=""name"">
        <br>Populacja <input type=""number"" id=""people"">
        <br><br><button id=""send"">dodaj</button><br>
         `
        let send = document.getElementById('send')
        let name = document.getElementById('name')
        let people = document.getElementById('people')
        send.onclick=()=>{{
          fetch('/villages/', {{
            method: 'POST',
            headers: {{
              'Content-Type': 'application/json',
              'Accept': 'application/json',
              }},
            body: `{{""name"":""${{name.value}}"", ""people"":${{people.value}}}}`,
            }})
            .then(response=>response.text())
            .then(text=>document.body.innerHTML = text)
        }}
      }}
    </script>
</html>
";
  await context.Response.WriteAsync(html);
});

app.MapGet("/villages/{id}", async (HttpContext context, int id) =>
{
  var village = villages[id];
  var html = $@"
<html>
    <head><meta charset=""UTF-8""></head>
    <body>
        <center>
        Panie, wieś <b>{village.name}</b> ma <b>{village.people}</b> mieszkańców.
        <br><br><button id=""del"">usuń</button>
        <button id=""ren"">zmień nazwę</button>
        <button id=""peo"">zmień liczbę mieszkańców</button>
        <div id=""inp""></div>
        <br><br><button onclick=""window.location.href='/'"">wróć</button>
        </center>
        <script>
        let del = document.getElementById('del')
        let ren = document.getElementById('ren')
        let peo = document.getElementById('peo')
        let inp = document.getElementById('inp')
        del.onclick = ()=>{{
          fetch('/villages/{id}', {{method: 'DELETE'}})
          .then(response => response.text())
          .then(text => document.body.innerHTML = text)
        }}
        ren.onclick = ()=>{{
          inp.innerHTML = '<br><input type=""text"" id=""renIn""> <button id=""send"">zmień</button><br>'
          let renIn = document.getElementById('renIn')
          let send = document.getElementById('send')
          send.onclick = ()=>{{
            fetch('/villages/{id}', {{
              method: 'PUT',
              headers: {{
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                }},
              body: `{{""name"":""${{renIn.value}}"", ""people"":{village.people}}}`,
              }})
            location.reload()
          }}
        }}
          peo.onclick = ()=>{{
          inp.innerHTML = '<br><input type=""number"" id=""renIn""> <button id=""send"">zmień</button><br>'
          let renIn = document.getElementById('renIn')
          let send = document.getElementById('send')
          send.onclick = ()=>{{
            fetch('/villages/{id}', {{
              method: 'PUT',
              headers: {{
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                }},
              body: `{{""name"":""{village.name}"", ""people"":${{renIn.value}}}}`,
              }})
            location.reload()
          }}
        }}
        </script>
    </body>
</html>
";
  await context.Response.WriteAsync(html);
});

app.MapPost("/villages/", async (HttpContext context, Village vilage) =>
{
  var exist = villages.Where(v => v.name == vilage.name);
  if (exist.Count() == 0)
  {
    villages.Add(vilage);
    await context.Response.WriteAsync(@$"
    <center>
    Panie, wieś <b>{vilage.name}</b> została dodana!<br>
    I liczy <b>{vilage.people}</b> mieszkańców.
  <br><br><button onclick=""window.location.href='/'"">wróć</button>
    </center>
  ");
  }
  else
    await context.Response.WriteAsync(@$"
    <center>
    Panie, wieś <b>{vilage.name}</b> jest już w twoim posiadaniu!
  <br><br><button onclick=""window.location.href='/'"">wróć</button>
    </center>
  ");
});
app.MapPut("/villages/{id}", (int id, Village vilage) => villages[id] = vilage);
app.MapDelete("/villages/{id}", async (HttpContext context, int id) =>
{
  var vilage = villages[id];
  villages.Remove(vilage);
  var html = $@"
<center>
  Panie, wieś <b>{vilage.name}</b> została usunięta zgodnie z twoją wolą!
  <br><br>
  <button onclick=""window.location.href='/'"">wróć</button>
</center>
";
  await context.Response.WriteAsync(html);
});

app.Run();

record Village(string name, int people);