using System;
using System.Management.Automation;

public static class GitManager
{
    public static bool IsRepositorio(string path)
    {
        if (path.Contains(".git") && !path.Contains(".gitignore"))
        {
            return true;
        }
            
        else
            return false;
    }

    public static void CloneRepositorio(string path , string link)
    {
        using var ps = PowerShell.Create();

        ps
            .AddCommand("cd")
            .AddArgument(path)
            .Invoke();
        ps
            .AddCommand("git")
            .AddArgument("clone")
            .AddArgument(link)
            .Invoke();

        Console.WriteLine("Clone realizado");
    }

    public async static Task Pull(string path)
    {
        if(IsRepositorio(path))
        {
            using var ps = PowerShell.Create();

            ps
                .AddCommand("cd")
                .AddArgument(path)
                .Invoke();

            ps
                .AddCommand("git")
                .AddArgument("pull")
                .Invoke();

            await DatabaseManager.editRepositorio(path);
        }
    }

    public async static Task PullAll(string path)
    {
        var projetos = Directory.GetFileSystemEntries(path);
        foreach (var projeto in projetos)
        {
            var arquivos = Directory.GetFileSystemEntries(projeto);
            foreach (var arquivo in arquivos)
            {
                var diretorio = Directory.GetParent(arquivo).ToString();
                await GitManager.Pull(diretorio);
               
                // using var ps = PowerShell.Create();
                // ps
                //     .AddCommand("cd")
                //     .AddArgument("C:/Users/disrct/Desktop/GitPsProject");
            }
        }
    }

}