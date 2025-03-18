using GerenciadorTarefas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração de páginas Razor
builder.Services.AddRazorPages();

// Configuração de autenticação baseada em cookies
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Login"; // Página de login
    });

// Configuração de proteção de dados
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/workspaces/gerenciador_tarefas/DataProtection-Keys"))
    .SetApplicationName("GerenciadorTarefas");

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Middleware
app.UseHttpsRedirection(); // Descomente esta linha para habilitar redirecionamento HTTPS
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Middleware de autenticação
app.UseAuthorization();  // Middleware de autorização
app.MapRazorPages();      // Certifique-se de que esta linha está presente
app.Run();
