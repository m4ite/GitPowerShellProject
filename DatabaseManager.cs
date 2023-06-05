using GitPsProject.Model;

public static class DatabaseManager
{
    static GitPsProjecContext context = new GitPsProjecContext();

    public async static Task addRepositorio(string path)
    {
        Repositorio table = new Repositorio()
        {
            Diretorio = path
        };

        context.Repositorios.Add(table);
        await context.SaveChangesAsync();
    }

    public async static Task find_add_Repositorio(string path)
    {
        var projetos = Directory.GetFileSystemEntries(path);
        foreach (var projeto in projetos)
        {
            var arquivos = Directory.GetFileSystemEntries(projeto);
            foreach (var arquivo in arquivos)
            {
                if (GitManager.IsRepositorio(arquivo))
                {
                    var diretorio = Directory.GetParent(arquivo).ToString();
                    await DatabaseManager.addRepositorio(diretorio);
                }
            }
        }
    }

    async public static Task editRepositorio(string path)
    {
        var repositorios =
            (from repositorio in context.Repositorios
             where repositorio.Diretorio == path
             select repositorio).First();

        repositorios.DataAtualização = DateTime.Now;
        await context.SaveChangesAsync();
    }

    async public static Task deleteRepositorio(string path)
    {
        var repositorios =
            (from repositorio in context.Repositorios
             where repositorio.Diretorio == path
             select repositorio).First();

        context.Remove(repositorios);
        context.SaveChanges();
    }


    public static void showValues()
    {
        var query =
        from repo in context.Repositorios
        select new
        {
            path = repo.Diretorio,
            date = repo.DataAtualização
        };

        foreach (var linha in query)
        {
            Console.WriteLine($"Diretorio: {linha.path} \nData_ultima_modificação: {linha.date} \n-------------------------- ");
        }
    }


}